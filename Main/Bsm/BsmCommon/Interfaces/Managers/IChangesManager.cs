using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IChangesManager
    {
        List<BudgetChange> GetBudgetChanges(int KodYechida, DateTime Month);
        List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan);
        List<BudgetSpecial> GetBudgetSpecial();
    }
}
