using CacheInfra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheInfra.Implement
{
    /// <summary>
    /// A .Net cache manager that is based on .Net's ObjectCache
    /// It has a policy for defining the different lifetime limitaitons + notifications before modification
    /// </summary>
    public class NetCacheManager : ICacheManager
    {
        private  ObjectCache cache = MemoryCache.Default;
        protected object syncObject = new object();

        protected virtual CacheItemPolicy GetPolicy()
        {
            var policy = new CacheItemPolicy();

            return policy;
        }

        protected virtual CacheItemPolicy GetTimedPolicy(TimeSpan timeLimit)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.Add(timeLimit);
            return policy;
        }

        public T Get<T>(string key) where T : class
        {
            return cache[key] as T; 
        }

        public object Get(string key)
        {
            return cache[key];
        }

        //Add an item to the cahce with no time limitation
        public void Add(string key, object value)
        {
            AddInternal(key, value, GetPolicy());
        }

        //This will add an item to the cache that will expire in the time limit defined
        public void Add(string key, object value, TimeSpan timeLimit)
        { 
            AddInternal(key,value, GetTimedPolicy(timeLimit));
        }

        private void AddInternal(string key, object value, CacheItemPolicy policy)
        {
            lock (syncObject)
            {
                cache.Set(key, value, policy);
            }
        }



        public void Remove(string key)
        {
            lock (syncObject)
            {
                if (cache.Contains(key))
                {
                    cache.Remove(key);
                }
            }
        }

        public void Update(string key, object value)
        {
            lock (syncObject)
            {
                //If the key exists - remove it
                if (Contains(key))
                {
                    Remove(key);
                }
                //in any case add the new key
                Add(key, value);
            }
        }

        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public void Clear()
        {
            //clearing all cache from the cahcne manager is not supported
            throw new NotImplementedException();
        }

        public int Count()
        {
            //counting all cache from the cahcne manager is not supported
            return cache.Count();
            
        }
    }
}
