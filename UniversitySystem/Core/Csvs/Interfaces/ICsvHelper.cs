using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICsvHelper
    {
        CsvFile Export<T>(List<T> items);
       // List<T> Import<T>(CsvFile csvFile);
    }
}