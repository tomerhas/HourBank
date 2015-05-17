using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheInfra.Interfaces
{
    public interface ICacheManager : ICachedDictionary<string,object>
    {
        T Get<T>(string key) where T : class;

        void Add(string key, object value, TimeSpan timeLimit);
    }
}
