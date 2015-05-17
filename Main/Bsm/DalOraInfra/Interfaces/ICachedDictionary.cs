using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheInfra.Interfaces
{
    public interface ICachedDictionary<TKey,TValue> 
    {
        TValue Get(TKey key) ;
        void Add(TKey key, TValue value);
        void Remove(TKey key);
        void Update(TKey key, TValue value);
        bool Contains(TKey key);
        void Clear();
        int Count();
    }
}
