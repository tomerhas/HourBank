using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using BsmCommon.UDT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IBudgetManager
    {
        List<MonthHolder> GetMonthsBack(int amountOfMonths);
        Budget GetBudget(int KodYechida, DateTime Month, long bakasha_id);

        List<BudgetEmployee> GetBudgetEmployees(int KodYechida, DateTime Month);
        List<Yechida> GetYechidot(string query);
        List<int> GetOvdimIdStartWith(string query);
        List<Oved> GetOvdimNameStartWith(string query);
        string GetOvedIdByName(string sName);
        string GetOvedNameById(string query);
        Yechida GetYechidaByName(string TeurYechida);
        List<BudgetEmployeeGrid> GetEmployeeDetails(int KodYechida, DateTime Month);
        void SaveEmployeeMichsot(COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot);
    }
}
