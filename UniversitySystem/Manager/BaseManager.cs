using ClassLibrary;
using System.Linq;
using UniversitySystem.Core.Exceptions;

namespace UniversitySystem.Manager
{
    public class BaseManager<T> where T : BaseEntity
    {
        protected RepositoryContext _context;
          
        public BaseManager(RepositoryContext context)
        {            
            _context = context;
        }

        public void Delete (int id)
        {            
            var entity = _context.Set<T>().Single(x => x.Id == id);

            if (entity == null)
                throw new UniversalException("$typeof(T).Name Not found id = $id");

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}