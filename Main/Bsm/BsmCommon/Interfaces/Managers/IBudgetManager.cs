using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IBudgetManager
    {
        List<MonthHolder> GetMonthsBack(int amountOfMonths);
        Budget GetBudget(int KodYechida, DateTime Month);

        List<BudgetEmployee> GetBudgetEmployees(int KodYechida, DateTime Month);
        List<Yechida> GetYechidot(string query);
        Yechida GetYechidaByName(string TeurYechida);
    }
}
