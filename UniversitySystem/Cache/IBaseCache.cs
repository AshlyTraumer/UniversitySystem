using System.Collections.Generic;
using System.Threading.Tasks;
using UniversitySystem.Models.ReportModel;

namespace UniversitySystem.Cache
{
    interface IBaseCache<T> where T : BaseReportModel
    {
           List<T> GetAllFromCache(string key);
       // T GetFromCache(string key);
    }
}
