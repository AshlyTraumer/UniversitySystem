using System.Collections.Generic;

namespace UniversitySystem.Report
{
    public interface IReport<TResult> :IQuery<List<TResult>>
    {
    }

    public interface IQuery<out TResult>
    {
        TResult Get();
    }
}