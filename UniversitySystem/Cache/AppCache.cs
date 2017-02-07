

using System;

namespace UniversitySystem.Cache
{
    public class AppCache
    {
        private static readonly object _lock = new object();
        private readonly System.Web.Caching.Cache _cache;

        public AppCache(System.Web.Caching.Cache cache)
        {
            _cache = cache;
        }       

        public T GetAllFromCache<T>(string key, Func<T> action)
        {
            var item = (T) _cache.Get(key);

            if (item == null)
            {
                lock (_lock)
                {
                    if (item == null)
                    {
                        item = action();

                        _cache.Insert(key, item);
                    }
                }
            }

            return item;
        }

        public T GetAllFromCache<TParam, T>(string key, Func<TParam, T> action, TParam param)
        {
            var item = (T)_cache.Get(key);

            if (item == null)
            {
                lock (_lock)
                {
                    if (item == null)
                    {
                        item = action(param);

                        _cache.Insert(key, item);
                    }
                }
            }

            return item;
        }


    }
}