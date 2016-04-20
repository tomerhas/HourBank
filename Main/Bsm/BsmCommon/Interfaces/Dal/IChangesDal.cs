using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Dal
{
    public interface IChangesDal
    {
        DataTable GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan);
    }
}
