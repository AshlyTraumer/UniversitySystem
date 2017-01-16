using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.DAO
{
    public abstract class DAO<T>
    {
        public RepositoryContext context = new RepositoryContext();
        abstract public IEnumerable<T> GetUsers();
        abstract public void Delete(int id);
        abstract public T GetById(int id);
        abstract public void Change(T instance);        
    }
}