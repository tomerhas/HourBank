using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Changes;
using BsmCommon.DataModels.Employees;
using BsmCommon.Interfaces.Dal;
using BsmCommon.Interfaces.Managers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers
{
    public class ChangesManager : IChangesManager
    {
        private IUnityContainer _container;

        public ChangesManager(IUnityContainer container)
        {
            _container = container;
        }

        public List<BudgetChange> GetBudgetChanges(int KodYechida, DateTime Month)
        {

            //   List<PirteyOved> empDetails = GetPirteyOvdim(KodYechida, Month);
            //   int[] ids = empDetails.Select(x => x.MisparIshi).ToArray();
            //  List<Oved> ovdim = GetOvdim(ids);
            List<BudgetChange> list = GetChanges(KodYechida, Month);
            int[] ids = list.Select(x => x.Meadken).ToArray();

            IGeneralManager manager = _container.Resolve<IGeneralManager>();
            List<Oved> ovdim = manager.GetOvdim(ids);

            EnrichBudgetChangesList(list, ovdim);
            return list;
        }

        private List<BudgetChange> GetChanges(int KodYechida, DateTime Month)
        {
            using (var context = new BsmEntities())
            {
                return context.BudgetChanges.Where(x => (x.FromYechida == KodYechida ||  x.ToYechida == KodYechida )&& x.Month == Month).ToList();
            }
        }

        public List<BudgetSpecialYechida> GetExtensionsBudget(int KodYechida, DateTime Month)
        {
            using (var context = new BsmEntities())
            {
                return context.BudgetSpecialYechida.Where(x => x.KodYechida == KodYechida && x.Chodesh == Month).ToList();

            }
        }

        public List<BudgetReduction> GetReductionsBudget(int KodYechida, DateTime Month)
        {
            using (var context = new BsmEntities())
            {
                return context.BudgetReduction.Where(x => x.KodYechida == KodYechida && x.Chodesh == Month).ToList();

            }
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

        public List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan)
        {
            List<BudgetChangesGrid> list = new List<BudgetChangesGrid>();
            var dt = _container.Resolve<IChangesDal>().GetChangesShaotNosafot(KodEzor, Month, isuk, KodMitkan);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(CreateBudgetEmployeeFromDataRow(dr));
            }
            return list;
        }

        public List<BudgetSpecial> GetBudgetSpecial()
        {
            List<BudgetSpecial> list = new List<BudgetSpecial>();
            BudgetSpecial bs;
            var dt = _container.Resolve<IChangesDal>().GetBudgetSpecial();
            foreach (DataRow  row in dt.Rows)
            {
                bs = new BudgetSpecial();
                bs.MisparTakziv=int.Parse(row["MISPAR_TAKZIV"].ToString());
                bs.Description = row["DESCRIPTION"].ToString();
                bs.Amount= int.Parse(row["AMOUNT"].ToString());
                bs.Reason = row["REASON"].ToString(); 
                list.Add(bs);
            }
            return list;
            //using (var context = new BsmEntities())
            //{
            //    return context.BudgetSpecial.ToList();
            //}
        }

        
        private BudgetChangesGrid CreateBudgetEmployeeFromDataRow(DataRow row)
        {
            //string erech;
            BudgetChangesGrid budgetChange = new BudgetChangesGrid();
           // budgetChange.Masad = int.Parse(row["MASAD"].ToString());
            budgetChange.Kod_Yechida = int.Parse(row["KOD_YECHIDA"].ToString());
            budgetChange.Teur_Yechida = row["TEUR_YECHIDA"].ToString();
            budgetChange.Takziv = decimal.Parse(row["Takziv"].ToString()) == 0 ? -9999 : decimal.Parse(row["Takziv"].ToString());//(row["Takziv"].ToString() == "0" || row["Takziv"].ToString() == "") ? "" : String.Format("{0:0.0}", decimal.Parse(row["Takziv"].ToString()));
            budgetChange.Yitra = decimal.Parse(row["Yitra"].ToString()) == 0 ? -9999 : decimal.Parse(row["Yitra"].ToString());//(row["Yitra"].ToString() == "0" || row["Yitra"].ToString() == "") ? "" : String.Format("{0:0.0}", decimal.Parse(row["Yitra"].ToString())); 
            budgetChange.Niyud = decimal.Parse(row["Niyud"].ToString()) == 0 ? -9999 : decimal.Parse(row["Niyud"].ToString()); //row["Niyud"].ToString() == "0" ? "" : row["Niyud"].ToString();
            budgetChange.AddRem = decimal.Parse(row["addrem"].ToString())==0 ? -9999 : decimal.Parse(row["addrem"].ToString());// erech;// row["addrem"].ToString() == "0" ? "" : row["addrem"].ToString(); 

            return budgetChange;
        }


        public void AddTakzivLeMitkan(int p_mitkan, DateTime p_chodesh, int p_id_takziv, decimal p_kamut, string p_reason, int p_user)
        {
            _container.Resolve<IChangesDal>().AddTakzivLeMitkan(p_mitkan, p_chodesh, p_id_takziv, p_kamut, p_reason, p_user);
        }

        public void AddNewTakziv(int p_id_takziv, string p_teur, decimal p_kamut, string p_reason, int p_user)
        {
            _container.Resolve<IChangesDal>().AddNewTakziv(p_id_takziv, p_teur, p_kamut, p_reason, p_user);
        }

        public void SaveChangeMitkan(int p_mitkan_from,int p_mitkan_to, DateTime p_chodesh, decimal p_erech, string p_reason, int p_user)
        {
            _container.Resolve<IChangesDal>().SaveChangeMitkan(p_mitkan_from, p_mitkan_to, p_chodesh, p_erech, p_reason, p_user);
        }

        public void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, decimal p_kamut, string p_reason, int p_user)
        {
            _container.Resolve<IChangesDal>().SaveReductionMitkan(p_mitkan, p_chodesh, p_kamut, p_reason, p_user);
        }

        public int GetNextTakzivNumber()
        {
            int num = 0;
            BudgetSpecial bs;
            using (var context = new BsmEntities())
            {
                bs = context.BudgetSpecial.OrderByDescending(X => X.MisparTakziv).FirstOrDefault();
                if (bs != null)
                    num = bs.MisparTakziv + 1;
            }
            return num;
        }

        public List<ChangeHistoryGrid> GetHistory(int p_mitkan, DateTime p_chodesh)
        {
            List<ChangeHistoryGrid> list = new List<ChangeHistoryGrid>();
            ChangeHistoryGrid ch;
            var dt = _container.Resolve<IChangesDal>().GetHistory(p_mitkan, p_chodesh);
            foreach (DataRow  row in dt.Rows)
            {
                ch = new ChangeHistoryGrid();
                ch.Kamut = decimal.Parse(row["kamut"].ToString());
                ch.SugPeula = row["sug_peula"].ToString();
                ch.Meadken = row["MEADKEN"].ToString();
                ch.TaarichIdkun = DateTime.Parse(row["TAARICH_IDKUN"].ToString());
                ch.Reason = row["REASON"].ToString();
                list.Add(ch);
            }
            return list;
        }

      public bool IsYechidaBetokef(int kodYechida, DateTime month)
      {
          
          DateTime to= month.AddMonths(1).AddDays(-1);
            using (var context = new BsmEntities())
            {
                var queryable = IsDateInRange(context, month, to);
                queryable = queryable.Where(x => x.KodYechida == kodYechida); 
       
                if (queryable.ToList().Count>0 )
                    return true;
                else return false;
            }
      }

      private IQueryable<BankMeshekYechida> IsDateInRange(BsmEntities context, DateTime from, DateTime to)
      {
          return context.BankMeshekYechida.Where(x => (to >= x.MeTaarich && to <= x.AdTaarich)
                || (from >= x.MeTaarich && from <= x.AdTaarich)
                || (from <= x.MeTaarich && to >= x.AdTaarich));

      }


    }
}
