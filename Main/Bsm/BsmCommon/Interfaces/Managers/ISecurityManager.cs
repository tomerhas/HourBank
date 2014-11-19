using BsmCommon.DataModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface ISecurityManager
    {
        UserInfo GetUserInfo(string UserName);
    }
}
