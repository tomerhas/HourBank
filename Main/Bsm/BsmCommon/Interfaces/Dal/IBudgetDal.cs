using BsmCommon.UDT;
using System;
using System.Data;
namespace BsmCommon.Interfaces.DAL
{
    public interface IBudgetDal
    {
        int GetSumMeafyen14(int KodYechida, DateTime Month);
        decimal GetShaotnosafotMeshek(int KodYechida, DateTime Month);
        DataTable GetEmployeeDatails(int KodYechida, DateTime Month);
        void SaveEmployeeMichsot(COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot);
    }
}
