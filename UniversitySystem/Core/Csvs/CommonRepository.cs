using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class CommonRepository : ICommonRepository
    {
        private readonly RepositoryContext _context;

        public CommonRepository(RepositoryContext context)
        {
            _context = context;
        }

       public void AddOrUpdate<T>(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>() where T : BaseEntity
        {
            return _context.Set<T>().ToList<T>();
        }
    }
}