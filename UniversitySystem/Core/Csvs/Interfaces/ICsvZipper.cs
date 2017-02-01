using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICsvZipper
    {
        byte[] Zip(List<CsvFile> csvFiles);
        List<CsvFile> Unzip(byte[] zipContent);
    }
}
