using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
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
        List<int> GetOvdimIdStartWith(string query);
        List<Oved> GetOvdimNameStartWith(string query);
        int GetOvedIdByName(string sName);
        string GetOvedNameById(string query);
        Yechida GetYechidaByName(string TeurYechida);
        List<BudgetChange> GetBudgetChanges(int KodYechida, DateTime Month);
    }
}
