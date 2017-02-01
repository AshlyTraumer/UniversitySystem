using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class CsvZipper : ICsvZipper
    {
        public byte[] Zip(List<CsvFile> csvFiles)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var csv in csvFiles)
                    {
                        var file = archive.CreateEntry(csv.FileName);

                        using (var streamWriter = new StreamWriter(file.Open(), Encoding.UTF8))
                        {
                            streamWriter.Write(string.Join("\n", csv.CsvStrings)); 
                        }
                    }

                }
                return memoryStream.GetBuffer();
            }
        }

        public List<CsvFile> Unzip(byte[] zipContent)
        {
            throw new NotImplementedException();
        }
    }
}