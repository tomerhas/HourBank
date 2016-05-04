using BsmCommon.UDT;
using System;
using System.Data;
namespace BsmCommon.Interfaces.DAL
{
    public interface IBudgetDal
    {
        decimal GetSumMeafyen14(int KodYechida, DateTime Month);
        decimal GetShaotnosafotMeshek(int KodYechida, DateTime Month);
        DataTable GetEmployeeDatails(int KodYechida, DateTime Month);
        int SaveEmployeeMichsot(int KodYechida, int userId, COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot);
        decimal GetFullBudgetToMitkan(int KodYechida, DateTime Month);
        void SaveBudgetLeft(int p_kod_yechida, DateTime p_chodesh, int p_user);
    }
}
