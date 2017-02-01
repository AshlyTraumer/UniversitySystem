using System.Collections.Generic;
using ClassLibrary;

namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICommonRepository
    {
        List<T> GetAll<T>() where T : BaseEntity;
        void AddOrUpdate<T>(IEnumerable<T> items) where T : BaseEntity;
    }
}
