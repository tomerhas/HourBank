using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Dal
{
    public interface IGeneralDal
    {
        DataTable GetYechidotForUser(DateTime Month, int isuk, int YechidaIrgunitOved, string PreFix="");
    }
}
