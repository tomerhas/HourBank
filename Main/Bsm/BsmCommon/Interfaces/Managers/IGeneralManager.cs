using BsmCommon.DataModels;
using BsmCommon.DataModels.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IGeneralManager
    {
        List<Oved> GetOvdim(int[] PirteyOvedIds);
        List<TeurEzor> GetEzors();
      
        DateTime GetZmanBakasha(long bakasha_id);
      
        /// <summary>
        /// ////////////

        string GetLastTaarichcalc(DateTime Month,int kodYechida);
        DateTime GetLastDateIdkunBank(DateTime Month);
        List<Yechida> GetYechidutForUser(DateTime Month, int KodYechida, string PreFix = "");
        long GetLastBakashaOfTeken(DateTime Month);
        long GetLastBakashatChishuvPremia();
    }
}
