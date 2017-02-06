using System.Collections.Generic;
using System.Runtime.Caching;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;
using UniversitySystem.Report;

namespace UniversitySystem.Cache
{
    public class ProfessorQueryCache : IBaseCache<ProfessorQueryModel>
    {
        private static readonly object _lock = new object();
        private static MemoryCache _cache;
        private readonly RepositoryContext _context;

        public ProfessorQueryCache(RepositoryContext context)
        {
            _context = context;
        }

        public List<ProfessorQueryModel> GetAllFromCache(string key)
        {
            lock (_lock)
            {
                _cache = MemoryCache.Default;

                var item = _cache.Get(key) as List<ProfessorQueryModel>;

                if (item == null)
                {
                    item = new ProfessorQuery(_context).Get();
                    _cache.Set(key, item, new CacheItemPolicy());
                }

                return item;
            }
        }
    }
}