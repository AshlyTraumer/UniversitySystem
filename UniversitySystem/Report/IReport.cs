using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversitySystem.Report
{
    public interface IReport<TResult> : IQuery<List<TResult>>
    {
    }

    public interface IQuery<TResult>
    {
        Task<TResult> GetAsync();
        TResult Get();
    }
}