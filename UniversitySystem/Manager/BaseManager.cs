using System;
using ClassLibrary;
using System.Linq;
using UniversitySystem.Core.Exceptions;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public abstract class BaseManager<T, TModel> where T : BaseEntity where TModel : ChangeModelBase
    {
        protected RepositoryContext Context;

        protected BaseManager(RepositoryContext context)
        {            
            Context = context;
        }

        public void Delete (int id)
        {            
            var entity = Context.Set<T>().Single(x => x.Id == id);

            if (entity == null)
                throw new UniversalException("$typeof(T).Name Not found id = $id");

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Single(x => x.Id == id);
        }

        protected abstract void Update(T entity, TModel model);

        public virtual void Change(TModel model)
        {
            var entity = GetById(model.Id);
            
            Update(entity, model);
            
            Context.SaveChanges();
        }
    }
}