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
        long GetLastBakasha(DateTime Month);
        DataTable GetYechidutForUser(DateTime Month, int KodYechida,string PreFix="");
    }
}
