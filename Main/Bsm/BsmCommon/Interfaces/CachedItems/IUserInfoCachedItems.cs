using BsmCommon.DataModels.Profiles;
using CacheInfra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.CachedItems
{
    public interface IUserInfoCachedItems : ICachedDictionary<string,UserInfo>
    {

    }
}
