using CacheInfra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheInfra.Implement
{
    public class CachedDictionary<TKey, TValue> : ICachedDictionary<TKey, TValue> where TValue :class
    {
        protected Dictionary<TKey, TValue> _cachedDictionary;
        protected object syncObject = new object();
        public CachedDictionary()
        {
            _cachedDictionary = new Dictionary<TKey, TValue>();
        }

        public TValue Get(TKey key)
        {
            lock (syncObject)
            {
                if (_cachedDictionary.ContainsKey(key))
                    return _cachedDictionary[key];
            }
            return null;
        }

        public void Add(TKey key, TValue value)
        {
            lock (syncObject)
            {
                if (!_cachedDictionary.ContainsKey(key))
                    _cachedDictionary.Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            lock (syncObject)
            {
                _cachedDictionary.Remove(key);
            }
        }

        public void Update(TKey key, TValue value)
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

        public bool Contains(TKey key)
        {
            lock (syncObject)
            {
                return _cachedDictionary.ContainsKey(key);
            }
        }


        public void Clear()
        {
            _cachedDictionary.Clear();
        }


        public int Count()
        {
            return _cachedDictionary.Count();
        }
    }
}
