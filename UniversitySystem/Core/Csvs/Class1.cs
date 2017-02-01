using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class Class1
    {
    }

    //public interface ICommonRepository
    //{
    //    List<T> GetAll<T>();
    //    void AddOrUpdate<T>(IEnumerable<T> items);
    //}

    //public interface ICsvHelper
    //{
    //    CsvFile Export<T>(List<T> items);
    //    List<T> Import<T>(CsvFile csvFile);
    //}

    //public interface ICsvZipper
    //{
    //    byte[] Zip(List<CsvFile> csvFiles);
    //    List<CsvFile> Unzip(byte[] zipContent);
    //}

    //public interface ICsvWrapper
    //{
    //    byte[] Export();
    //    void Import(byte[] zipContent);
    //}

    //public class CsvWrapper : ICsvWrapper
    //{
    //    private readonly ICommonRepository _commonRepository;
    //    private readonly ICsvHelper _csvHelper;
    //    private readonly ICsvZipper _csvZipper;

    //    //TODO throw argumentnullexception
    //    public CsvWrapper(ICommonRepository commonRepository, ICsvHelper csvHelper, ICsvZipper csvZipper)
    //    {
    //        _commonRepository = commonRepository;
    //        _csvHelper = csvHelper;
    //        _csvZipper = csvZipper;
    //    }


    //    public byte[] Export()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Import(byte[] zipContent)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //TODO throw argumentnullexception
    //public class CsvFile
    //{
    //    public string FileName { get; private set; }

    //    public IReadOnlyList<string> CsvStrings { get; private set; }

    //    public CsvFile(string fileName, IEnumerable<string> csvStrings)
    //    {
    //        FileName = fileName;
    //        CsvStrings = new ReadOnlyCollection<string>(csvStrings.ToList());
    //    }
    //}
}