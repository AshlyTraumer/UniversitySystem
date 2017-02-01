using System.Collections.Generic;

namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICsvHelper
    {
        CsvFile Export<T>(List<T> items);
       // List<T> Import<T>(CsvFile csvFile);
    }
}