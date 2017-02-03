using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversitySystem.Report
{
    public interface IReportParam<T,TResult> : IQueryParam<T,List<TResult>>
    {
    }

    public interface IQueryParam<in T, TResult>
    {
        Task<TResult> GetAsync(T param);
        TResult Get(T param);
    }
}