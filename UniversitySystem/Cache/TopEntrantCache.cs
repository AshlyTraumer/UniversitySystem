using System.Collections.Generic;
using System.Runtime.Caching;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;
using UniversitySystem.Report;

namespace UniversitySystem.Cache
{
    public class TopEntrantCache : IBaseCache<TopEntrantModel>
    {
        private static readonly object _lock = new object();
        private static MemoryCache _cache;
        private readonly RepositoryContext _context;

        public TopEntrantCache(RepositoryContext context)
        {
            _context = context;
        }

       /* public TopEntrantModel GetFromCache(string key)
        {
            lock (_lock)
            {
                _cache = MemoryCache.Default;
                
                var item = _cache.Get(string.Concat("te_",key)) as TopEntrantModel;
                if (item == null)
                {
                    item = new TopEntrantQuery(_context)
                        .Get()
                        .Single(q => q.Passport == key);

                    _cache.Add(string.Concat("te_", key), item, new CacheItemPolicy());
                }

                return item;
            }
        }*/

        public List<TopEntrantModel> GetAllFromCache(string key)
        {
            lock (_lock)
            {
                _cache = MemoryCache.Default;

                var item = _cache.Get(key) as List<TopEntrantModel>;
                if (item == null)
                {
                    item = new TopEntrantQuery(_context).Get();
                    _cache.Set(key, item, new CacheItemPolicy());
                }
                return item;
            }
        }


    }
}