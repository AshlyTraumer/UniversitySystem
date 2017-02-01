using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniversitySystem.Core.Csvs
{
    public class CsvFile
    {
        public string FileName { get; private set; }

        public IReadOnlyList<string> CsvStrings { get; private set; }

        public CsvFile(string fileName, IEnumerable<string> csvStrings)
        {
            if ((fileName == null) || (csvStrings == null))
                throw new ArgumentNullException();

            FileName = fileName;
            CsvStrings = new ReadOnlyCollection<string>(csvStrings.ToList());
        }
    }
}