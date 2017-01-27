using System.Collections.Generic;

namespace UniversitySystem.Report
{
    public interface IReportParam<T,TResult> : IQueryParam<T,List<TResult>>
    {
    }

    public interface IQueryParam<in T, out TResult>
    {
        TResult Get(T param);
    }
}