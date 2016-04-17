using BsmBL.DAL;
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
                return context.BudgetChanges.Where(x => x.KodYechida == KodYechida && x.Month == Month).ToList();

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

        public List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, int KodMitkan, DateTime Month)
        {
            List<BudgetChangesGrid> list = new List<BudgetChangesGrid>();
            var dt = _container.Resolve<IChangesDal>().GetChangesShaotNosafot(KodEzor, KodMitkan, Month);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(CreateBudgetEmployeeFromDataRow(dr));
            }
            return list;
        }

        public List<BudgetSpecial> GetBudgetSpecial()
        {
            using (var context = new BsmEntities())
            {
                return context.BudgetSpecial.ToList();
                //var sql = string.Format("select * from TB_BUDGET_SPECIAL");
                //var res = context.Database.SqlQuery<BudgetSpecial>(sql).OrderBy(e => e.MisparTakziv);
                //return res.ToList();
            }
        }

        
        private BudgetChangesGrid CreateBudgetEmployeeFromDataRow(DataRow row)
        {
            BudgetChangesGrid budgetChange = new BudgetChangesGrid();
           // budgetChange.Masad = int.Parse(row["MASAD"].ToString());
            budgetChange.Mitkan = int.Parse(row["Mitkan"].ToString());
            budgetChange.Takziv = float.Parse(row["Takziv"].ToString());
            budgetChange.Yitra = float.Parse(row["Yitra"].ToString());
            budgetChange.Miztaber = float.Parse(row["Miztaber"].ToString());
            budgetChange.Reason = row["REASON"].ToString();

            return budgetChange;
        }
    }
}
