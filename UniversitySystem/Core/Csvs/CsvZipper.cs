using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
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
                            streamWriter.Write(string.Join("\r\n", csv.CsvStrings));
                        }
                    }

                }

                return memoryStream.GetBuffer();
            }
        }

        public List<CsvFile> Unzip(byte[] zipContent)
        {
            var csvList = new List<CsvFile>();

            var stream = new MemoryStream();
            stream.Write(zipContent, 0, zipContent.Length);

            using (var archive = new ZipArchive(stream, ZipArchiveMode.Read, true))
            {
                foreach (var entry in archive.Entries)
                {
                    using (var reader = new StreamReader(entry.Open()))
                    {
                        var list = reader.ReadToEnd()
                            .Split('\n')
                            .ToList();

                        csvList.Add(new CsvFile(entry.FullName, list));
                    }
                }
            }

            return csvList;
        }
    }
}