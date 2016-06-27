using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using BsmCommon.Helpers;
using BsmCommon.Interfaces.Managers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using BsmCommon.Interfaces.DAL;
using BsmCommon.UDT;
using System.Diagnostics;
using BsmCommon.DataModels.Changes;

namespace BsmBL.Managers
{
    public class BudgetManager : IBudgetManager
    {
        private IUnityContainer _container;

        public BudgetManager(IUnityContainer container)
        {
            _container = container;
        }
        public List<MonthHolder> GetMonthsBack(int KodParam)
        {
            int num = GetMonthsBackFromParameters(KodParam);
            var list = new List<MonthHolder>();
            var date = DateTime.Now;
            for (int i = 0; i < num; i++ )
            {
                var id = date.Month.ToString().PadLeft(2, '0') + "/" + date.Year;
                var text = DateHelper.getMonthHeb(date.Month) + " " + date.Year;
                list.Add(new MonthHolder() { Id = "01/" + id, Val = text });
                //list.Add(new MonthHolder() { Id = "01/05/2014", Val = "05/2014" });
                date = date.AddMonths(-1);
            }
            return list;
        }

        public Budget GetBudgetDetails(int KodYechida, DateTime Month)
        {
        
            Budget budget = null;
          //  Budget budgetPrevMonth = null;

            using (var context = new BsmEntities())
            {
                budget =GetBudget( KodYechida , Month);
                if (budget != null)
                {
                    var BudgetDal = _container.Resolve<IBudgetDal>();
                    budget.BudgetUsed = BudgetDal.GetShaotnosafotMeshek(KodYechida, Month);
                    budget.ShaotByMeafyen14 = GetSachMeafyen14(KodYechida, Month);
                    budget.YitratTakzivToDivide = GetBudgetLeft(KodYechida, Month);// budget.BudgetVal - budget.ShaotByMeafyen14;
                    budget.BudgetVal = BudgetDal.GetFullBudgetToMitkan(KodYechida, Month);// +GetBudgetLeft(KodYechida, Month.AddMonths(-1));   
                }
            }


            return budget;

        }
        public float GetBudgetLeft(int KodYechida, DateTime Month)
        {
            BudgetLeft budgetLeft = null;
            using (var context = new BsmEntities())
            {
                budgetLeft = context.BudgetLeft.FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == Month);
                if (budgetLeft != null)
                {
                    return budgetLeft.BudgetLeftAmount;// decimal.Parse(String.Format("{0:0.0}", budgetLeft.BudgetLeftAmount));
                }
            }
            return 0;
        }
        public Budget GetBudget(int KodYechida, DateTime Month)
        {
            Budget budget = null;

            using (var context = new BsmEntities())
            {
                budget = context.Budgets.OrderByDescending(X => X.TaarichIdkun).FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == Month);
              
            }
            return budget;
        }
      

        //public Budget GetBudget(int KodYechida, DateTime Month, long bakasha_id)
        //{
        //    long  bakasha_id_prev=0;
        //    Budget budget = null;
        //    Budget budgetPrevMonth = null;
        //    int ToAdd, ToSubtract, prevChanges=0;
        //   // Budget budgetUsed = null;

        //    IGeneralManager manager = _container.Resolve<IGeneralManager>();
        //    bakasha_id_prev = manager.GetLastBakasha(Month.AddMonths(-1));
        //    using (var context = new BsmEntities())
        //    {
        //        budget = context.Budgets.OrderByDescending(X => X.TaarichIdkun).FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == Month && x.BakashaId == bakasha_id);
        //        DateTime prevMonth = DateHelper.GetPreviosMonth(Month);
        //        budgetPrevMonth = context.Budgets.OrderByDescending(X => X.TaarichIdkun).FirstOrDefault(x => x.KodYechida == KodYechida && x.Month == prevMonth && x.BakashaId == bakasha_id_prev);
        //        if (budget != null)
        //        { 
        //            budget.BudgetChanges = context.BudgetChanges.Where(x => x.KodYechida == KodYechida && x.Month == Month).ToList();

        //           // DateTime prevMonth = DateHelper.GetPreviosMonth(Month);
        //           // budgetUsed = context.Budgets.SingleOrDefault(x => x.KodYechida == KodYechida && x.Month == prevMonth);
        //        }
        //        if (budgetPrevMonth != null)
        //        {
        //            budgetPrevMonth.BudgetChanges = context.BudgetChanges.Where(x => x.KodYechida == KodYechida && x.Month == prevMonth).ToList();
        //        }
        //    }

        //    //הפחתה/הוספה ש''נ
        //    if (budget != null && budget.BudgetChanges.Count > 0)
        //    {
        //         ToAdd = budget.BudgetChanges.Where(x => x.Type == 1).Sum(x => x.Val);
        //         ToSubtract = budget.BudgetChanges.Where(x => x.Type == 2).Sum(x => x.Val);

        //        budget.AddSubtractHours = ToAdd - ToSubtract;
        //    }


        //    if (budgetPrevMonth != null && budgetPrevMonth.BudgetChanges.Count > 0)
        //    {
        //         ToAdd = budgetPrevMonth.BudgetChanges.Where(x => x.Type == 1).Sum(x => x.Val);
        //         ToSubtract = budgetPrevMonth.BudgetChanges.Where(x => x.Type == 2).Sum(x => x.Val);

        //         prevChanges =  ToAdd - ToSubtract;

                  
        //    }
           


        //    //סה''כ תקציב ש''נ
        //    if (budget != null)
        //    {
        //        budget.RemainHoursLastMonth = (budgetPrevMonth.BudgetVal + prevChanges) - budgetPrevMonth.BudgetUsed;
        //        int val = budget.BudgetVal + budget.AddSubtractHours + budget.RemainHoursLastMonth;
        //        //if(budgetPrevMonth != null)
        //        //    val -= budgetPrevMonth.BudgetUsed;
                
        //        budget.SachTakzivShaotNosafot = val;

        //        var BudgetDal = _container.Resolve<IBudgetDal>();

        //        budget.YitratTakzivToDivide = budget.SachTakzivShaotNosafot - BudgetDal.GetSumMeafyen14(KodYechida, Month, bakasha_id);
        //        budget.HoursNotUsed = budget.SachTakzivShaotNosafot - BudgetDal.GetShaotnosafotMeshek(KodYechida, Month, bakasha_id);
        //    }
            
             
        //    return budget;

        //}



        private float GetSachMeafyen14(int KodYechida, DateTime Month)
        {  
                var BudgetManager = _container.Resolve<IBudgetDal>();
                float sum = BudgetManager.GetSumMeafyen14(KodYechida, Month);
                return sum;     
        }


        public List<BudgetEmployee> GetBudgetEmployees(int KodYechida, DateTime Month)
        {
            IGeneralManager manager = _container.Resolve<IGeneralManager>();

            List<PirteyOved> empDetails = GetPirteyOvdim(KodYechida, Month);
            int[] ids = empDetails.Select(x => x.MisparIshi).ToArray();
            List<Oved> ovdim = manager.GetOvdim(ids);
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

        public string GetOvedIdByName(string query)
        {
            int valQuery = -1;
            if (string.IsNullOrEmpty(query))
            {
                return "";
            }
            using (var db = new KdsEntities())
            {
                var sql = string.Format("select mispar_ishi from ovdim where (shem_mish || ' ' ||  shem_prat) = '{0}'", query);
                var res = db.Database.SqlQuery<int>(sql).ToList();


                // oved = db.Ovdim.Where(x => x.FullName == query).ToList();
                if (res.Count > 0)
                    return res[0].ToString(); //oved[0].MisparIshi;// db.Ovdim.Where(x => x.FullName.StartsWith(query)).ToList();
                else
                    return "";
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

      

        public List<BudgetEmployeeGrid> GetEmployeeDetails(int KodYechida, DateTime Month)
        {
            List<BudgetEmployeeGrid> list = new List<BudgetEmployeeGrid>();
             var dt = _container.Resolve<IBudgetDal>().GetEmployeeDatails(KodYechida, Month);
   
            foreach (DataRow dr in dt.Rows)
             {
                 list.Add(CreateBudgetEmployeeFromDataRow(dr));
             }
    
             return list;
        }

        private BudgetEmployeeGrid CreateBudgetEmployeeFromDataRow(DataRow row)
        {
            BudgetEmployeeGrid budgetEmployee = new BudgetEmployeeGrid();
            budgetEmployee.Masad = int.Parse(row["MASAD"].ToString());
            budgetEmployee.MisparIshi = int.Parse(row["mispar_ishi"].ToString());
            budgetEmployee.FullName = row["Full_Name"].ToString();
            budgetEmployee.TeurIsuk = row["Teur_Isuk"].ToString();
            budgetEmployee.AlTikni = row["Al_Tikni"].ToString();
            budgetEmployee.TeurMutamut = row["Teur_Mutamut"].ToString();
            budgetEmployee.TeurGil = row["TEUR_KOD_GIL"].ToString();
            budgetEmployee.MichsaYomit = float.Parse(row["Michsa_Yomit"].ToString());
            budgetEmployee.NosafotPrev = float.Parse(row["Nosafot_Prev"].ToString());
            // budgetEmployee.MichsaPrev = float.Parse(row["Michsa_Prev"].ToString());
            budgetEmployee.MichsaCur = float.Parse(row["Michsa_Cur"].ToString());
            budgetEmployee.MichsaMakor = budgetEmployee.MichsaCur;
            //   budgetEmployee.NosafotCur = float.Parse(row["Nosafot_Cur"].ToString());

            budgetEmployee.ShaotShebuzu = float.Parse(row["ShaotShebuzu"].ToString());
            budgetEmployee.MisSign = int.Parse(row["mis_sign"].ToString());
            decimal paar = (decimal)budgetEmployee.ShaotShebuzu - (decimal)budgetEmployee.MichsaCur;

            if (paar < 0)
                budgetEmployee.Paar =  paar;// string.Concat(paar * (-1), "-");
                                           // budgetEmployee.Paar =
            else
            {
                if (paar == 0)
                    budgetEmployee.Paar = 0;// "0";
                else budgetEmployee.Paar =  paar;// paar.ToString();
            }
            // budgetEmployee.CurYechida = int.Parse(row["cur_yechida"].ToString());

            var isuk_meshek = int.Parse(row["isuk_meshek"].ToString());
            var budget_calc = int.Parse(row["BUDGET_CALC"].ToString());

            var exists_in_mitkan = row["exist_in_mitkan"].ToString();
            var mutaam = row["mutaam"].ToString();
            if (budgetEmployee.MisparIshi == 29152)
            {
                var x = budgetEmployee.MisparIshi;
            }
                if (budgetEmployee.AlTikni == "כן" || mutaam == "1" || mutaam == "3" || mutaam == "5" || mutaam == "7" || exists_in_mitkan == "0" || isuk_meshek == 0 || budget_calc==0)
                budgetEmployee.ReadOnly ="true";
            else budgetEmployee.ReadOnly = "false";
        //    budgetEmployee.NosafotNotUsed = float.Parse(row["Nosafot_Not_Used"].ToString());
          //  budgetEmployee.Meafyen14 = float.Parse(row["Meafyen14"].ToString());
            return budgetEmployee;
        }

        public int SaveEmployeeMichsot(int KodYechida, int userId, COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot)
        {
            var BudgetDal = _container.Resolve<IBudgetDal>();
            return BudgetDal.SaveEmployeeMichsot(KodYechida, userId,ocollMichsot);
        }

        public void SaveBudgetLeft(int p_kod_yechida, DateTime p_chodesh, int p_user)
        {
            _container.Resolve<BudgetDal>().SaveBudgetLeft(p_kod_yechida, p_chodesh, p_user);
        }

        public float GetBudgetLeftForMitkan(int p_kod_yechida, DateTime p_chodesh)
        { 
            using (var db = new BsmEntities())
            {
                var left = db.BudgetLeft.FirstOrDefault(f => f.KodYechida == p_kod_yechida && f.Month == p_chodesh);
                if (left != null)
                    return left.BudgetLeftAmount; 
            }
            return 0;
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
