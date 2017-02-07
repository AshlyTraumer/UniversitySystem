using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversitySystem.Report;

namespace UniversitySystem.Cache
{
    public class DecoratorCache<TResult> : IReport<TResult>
    {
        private static readonly object _lock = new object();
        private readonly System.Web.Caching.Cache _cache;
        private string _key;

        private readonly IReport<TResult> _component;

        public DecoratorCache(IReport<TResult> component)
        {
            _component = component;
        }

        public DecoratorCache<TResult> SetKey(string key)
        {
            _key = key;
            return this;
        }

        public List<TResult> Get()
        {
            if (_key == "") throw new ArgumentNullException();

            var item = _cache.Get(_key);

            if (item == null)
            {
                lock (_lock)
                {
                    if (item == null)
                    {
                        item = _component.Get();

                        _cache.Insert(_key, item);
                    }
                }
            }

            return (List<TResult>) item;
        }

        

        Task<List<TResult>> IQuery<List<TResult>>.GetAsync()
        {
            throw new NotImplementedException();
        }

        
    }

    
}