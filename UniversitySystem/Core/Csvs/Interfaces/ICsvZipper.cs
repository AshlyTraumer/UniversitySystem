using System.Collections.Generic;

namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICsvZipper
    {
        byte[] Zip(List<CsvFile> csvFiles);
        List<CsvFile> Unzip(byte[] zipContent);
    }
}
