using BsmCommon.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IGeneralManager
    {
        List<Ezor> GetEzors();
    }
}
