﻿using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using BsmCommon.Helpers;
using BsmCommon.Interfaces.Managers;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers
{
    public class BudgetManager : IBudgetManager
    {
        public List<MonthHolder> GetMonthsBack(int KodParam)
        {
            int num = GetMonthsBackFromParameters(KodParam);
            var list = new List<MonthHolder>();
            var date = DateTime.Now;
            for (int i = 0; i < num; i++ )
            {
                var id = date.Month.ToString().PadLeft(2, '0') + "/" + date.Year;
                list.Add(new MonthHolder() { Id = "01/"+  id, Val = id });
                //list.Add(new MonthHolder() { Id = "01/05/2014", Val = "05/2014" });
                date = date.AddMonths(-1);
            }
            return list;
        }

        public Budget GetBudget(int KodYechida, DateTime Month)
        {
            Budget budget = null;
            Budget budgetPrevMonth = null;
           // Budget budgetUsed = null;
            using (var context = new BsmEntities())
            {
                budget = context.Budgets.OrderByDescending(X => X.TaarichIdkun).FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == Month);
                DateTime prevMonth = DateHelper.GetPreviosMonth(Month);
                budgetPrevMonth = context.Budgets.OrderByDescending(X => X.TaarichIdkun).FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == prevMonth);
                if (budget != null)
                {
                    
                    budget.BudgetChanges = context.BudgetChanges.Where(x => x.KodYechida == KodYechida && x.Month == Month).ToList();

                   // DateTime prevMonth = DateHelper.GetPreviosMonth(Month);
                   // budgetUsed = context.Budgets.SingleOrDefault(x => x.KodYechida == KodYechida && x.Month == prevMonth);
                }
            }

            //הפחתה/הוספה ש''נ
            if (budget != null && budget.BudgetChanges.Count > 0)
            {
                int ToAdd = budget.BudgetChanges.Where(x => x.Type == 1).Sum(x => x.Val);
                int ToSubtract = budget.BudgetChanges.Where(x => x.Type == 2).Sum(x => x.Val);

                budget.AddSubtractHours = ToAdd - ToSubtract;
            }
            //סה''כ תקציב ש''נ
            if (budget != null)
            {
                int val = budget.BudgetVal + budget.AddSubtractHours;
                if(budgetPrevMonth != null)
                    val -= budgetPrevMonth.BudgetUsed;
                
                budget.SachTakzivShaotNosafot = val;
            }
            

            return budget;

        }

        public List<BudgetEmployee> GetBudgetEmployees(int KodYechida, DateTime Month)
        {
            List<PirteyOved> empDetails = GetPirteyOvdim(KodYechida, Month);
            int[] ids = empDetails.Select(x => x.MisparIshi).ToArray();
            List<Oved> ovdim = GetOvdim(ids);
            List<BudgetEmployee> list = GetBudgetOvdim(ids, Month);
            EnrichBudgetmployeeList(list, ovdim, empDetails);
            return list;
        }

        private void EnrichBudgetmployeeList(List<BudgetEmployee> list, List<Oved> ovdim, List<PirteyOved> empDetails)
        {
            list.ForEach(budgetEmployee => 
            {
                var oved = ovdim.SingleOrDefault(x => x.MisparIshi == budgetEmployee.MisparIshi);
                if (oved != null)
                {
                    budgetEmployee.FirstName = oved.FirstName;
                    budgetEmployee.LastName = oved.LastName;
                }
            });
        }

        private List<BudgetEmployee> GetBudgetOvdim(int[] ids, DateTime month)
        {
            using (var context = new BsmEntities())
            {
                return context.Employees.Where(x => ids.Contains(x.MisparIshi) && x.Month == month).ToList();
            }
        }
        private List<PirteyOved> GetPirteyOvdim(int KodYechida, DateTime Month)
        {
            DateTime EndOfMonth= Month.AddMonths(1).AddDays(-1);
            using (var context = new KdsEntities())//עומדים לעבוד מול הטבלאות של kds Entiti
            {
                var queryable = IsDateInRange(context, Month, EndOfMonth);
                queryable =  queryable.Where(x => x.YechidaIrgunit == KodYechida);
                return queryable.ToList();
            }
            //List<PirteyOved> empDetails;
            //DateTime EndOfMonth= Month.AddMonths(1).AddDays(-1);
            //using (var context = new KdsEntities())//עומדים לעבוד מול הטבלאות של kds Entiti
            //{
            //    var parFromDate = new OracleParameter("p_tar_me", OracleDbType.Date, Month, ParameterDirection.Input);
            //    var parToDate = new OracleParameter("p_tar_ad", OracleDbType.Date, EndOfMonth, ParameterDirection.Input);
            //    var parYechida = new OracleParameter("p_yechida", OracleDbType.Int32, KodYechida, ParameterDirection.Input);
            //    var result = new OracleParameter("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);

            //    empDetails =  context.Database.SqlQuery<PirteyOved>("begin Pkg_Ovdim.pro_get_ovdim_to_yechida(:p_tar_me,:p_tar_ad,:p_yechida,:result); end;", parFromDate, parToDate, parYechida, result).ToList();
            //}
            //return empDetails;
        }

        private IQueryable<PirteyOved> IsDateInRange(KdsEntities context,DateTime from, DateTime to)
        {
            return context.PirteyOvdim.Where(x => (to >= x.TaarichMe && to <= x.TaarichAd)
                || (from >= x.TaarichMe && from <= x.TaarichAd)
                || (from <= x.TaarichMe && to >= x.TaarichAd));
                
        }

        private List<Oved> GetOvdim(int[] PirteyOvedIds)
        {
            using (var context = new KdsEntities())
            {
                var result = context.Ovdim.Where(x => PirteyOvedIds.Contains(x.MisparIshi)).ToList();
                return result;
            }
        }
        
        private int GetMonthsBackFromParameters(int KodParam)
        {
            using (var context = new BsmEntities())
            {
                DateTime today= DateTime.Now;
                int result = -1;
                var param = context.Parameters.SingleOrDefault(x => x.KodParam == KodParam && today >= x.TaarichMe && today <= x.TaarichAd);
                if (param != null)
                {
                   int.TryParse(param.Val, out result);              
                }
                return result;
            }
        }

        public List<Yechida> GetYechidot(string query)
        {
            using (var db = new KdsEntities())
            {
                return String.IsNullOrEmpty(query) ? db.Yechidot.ToList() :
                db.Yechidot.Where(y => y.TeurYechida.StartsWith(query)).ToList();
            }   
        }

        public List<int> GetOvdimIdStartWith(string query)
        {

            using (var db = new KdsEntities())
            {
                if (String.IsNullOrEmpty(query.Trim()))
                    return new List<int>();
                else
                {
                    var sql = string.Format("select mispar_ishi from ovdim where to_char(mispar_ishi) like '{0}%'", query);
                    var res = db.Database.SqlQuery<int>(sql);
                    //var res = db.Ovdim.Where(x => x.to_char(x.MisparIshi).Contains("12"));
                    return res.ToList();
                    //var res = db.Ovdim.Where(x => SqlFunctions.StringConvert((double)x.MisparIshi).TrimStart().StartsWith(query));
                    //    return res.ToList();
                }
            }
        }

        public List<Oved> GetOvdimNameStartWith(string query)
        {
            using (var db = new KdsEntities())
            {
                return String.IsNullOrEmpty(query.Trim()) ? new List<Oved>() :
                  db.Ovdim.Where(x => x.LastName.StartsWith(query)).ToList();
            }
           
        }

        public int GetOvedIdByName(string query)
        {
            using (var db = new KdsEntities())
            {
                var sql = string.Format("select mispar_ishi from ovdim where (shem_mish || ' ' ||  shem_prat) = '{0}'", query);
                var res = db.Database.SqlQuery<int>(sql).ToList();


               // oved = db.Ovdim.Where(x => x.FullName == query).ToList();

                return res[0]; //oved[0].MisparIshi;// db.Ovdim.Where(x => x.FullName.StartsWith(query)).ToList();
            }
           
        }
        public string GetOvedNameById(string query)
        {
            int valQuery = -1;
            if (!int.TryParse(query, out valQuery))
            {
                return "";
            }
            using (var db = new KdsEntities())
            {
                var sql = string.Format("select shem_mish || ' ' ||  shem_prat fullname from ovdim where to_char(mispar_ishi) = '{0}'", query);
                var res = db.Database.SqlQuery<string>(sql).ToList();


               // oved = db.Ovdim.Where(x => x.FullName == query).ToList();
                if (res.Count > 0)
                    return res[0]; //oved[0].MisparIshi;// db.Ovdim.Where(x => x.FullName.StartsWith(query)).ToList();
                else
                    return "";
            }
           
        }
        
        public Yechida GetYechidaByName(string TeurYechida)
        {//מה קורה כשיש 2 שעונים על אותה הגדרה
            using (var db = new KdsEntities())
            {
                 return db.Yechidot.SingleOrDefault(y => y.TeurYechida.Trim().Equals(TeurYechida.Trim()));
            }   
        }

        public List<BudgetChange> GetBudgetChanges(int KodYechida, DateTime Month)
        {
          
         //   List<PirteyOved> empDetails = GetPirteyOvdim(KodYechida, Month);
         //   int[] ids = empDetails.Select(x => x.MisparIshi).ToArray();
          //  List<Oved> ovdim = GetOvdim(ids);
            List<BudgetChange> list = GetBudgeChanges(KodYechida, Month);
            int[] ids = list.Select(x => x.Meadken).ToArray();
            List<Oved> ovdim = GetOvdim(ids);

             EnrichBudgetChangesList(list, ovdim);
            return list;
        }

        private void EnrichBudgetChangesList(List<BudgetChange> list, List<Oved> ovdim)
        {
            list.ForEach(budgetChange =>
            {
                var oved = ovdim.SingleOrDefault(x => x.MisparIshi == budgetChange.Meadken);
                if (oved != null)
                {
                    budgetChange.MeadkenName = oved.FirstName + " " + oved.LastName;
              
                }
            });
        }

        private List<BudgetChange> GetBudgeChanges(int KodYechida, DateTime Month)
        {
            using (var context = new BsmEntities())
            {
                return context.BudgetChanges.Where(x => x.KodYechida == KodYechida && x.Month == Month).ToList();

            }
        }
    }


   
    //empDetails = context.PirteyOvdim.Where(x => x.YechidaIrgunit == KodYechida &&
    //                (
    //                    (Month >= x.TaarichMe && Month<=x.TaarichAd) ||
    //                    (EndOfMonth >= x.TaarichMe && EndOfMonth <= x.TaarichAd)  ||
    //                    (x.TaarichMe >= Month && x.TaarichAd <= EndOfMonth)
    //                 )
    //             ).ToList();
}
