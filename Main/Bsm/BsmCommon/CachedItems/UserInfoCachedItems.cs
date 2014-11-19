using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using CacheInfra.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.CachedItems
{
    public class UserInfoCachedItems : CachedDictionary<string, UserInfo>, IUserInfoCachedItems
    {
    }
}
