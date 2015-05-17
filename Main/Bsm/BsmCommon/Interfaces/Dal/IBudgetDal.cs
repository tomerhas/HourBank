using System;
using System.Data;
namespace BsmCommon.Interfaces.DAL
{
    public interface IBudgetDal
    {
        int GetSumMeafyen14(int KodYechida, DateTime Month, long BakashaId);
        int GetShaotnosafotMeshek(int KodYechida, DateTime Month, long BakashaId);
        DataTable GetEmployeeDatails(int KodYechida, DateTime Month, long BakashaId);
    }
}
