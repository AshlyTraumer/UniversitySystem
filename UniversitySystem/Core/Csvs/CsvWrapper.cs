using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;
using UniversitySystem.Core.Csvs.Interfaces;
using static System.String;

namespace UniversitySystem.Core.Csvs
{
    public class CsvWrapper : ICsvWrapper
    {
        private readonly ICommonRepository _commonRepository;
        private readonly ICsvHelper _csvHelper;
        private readonly ICsvZipper _csvZipper;
        private const string AssemblyName = "ClassLibrary.{0},ClassLibrary";
        
        public CsvWrapper(ICommonRepository commonRepository, ICsvHelper csvHelper, ICsvZipper csvZipper)
        {
            if (commonRepository == null)
                throw new ArgumentNullException("CsvWrapperError: commonRepository is null");
            else
            {
                if (csvHelper == null)
                    throw new ArgumentNullException("CsvWrapperError: csvHelper is null");
                else
                {
                    if (csvZipper == null)
                        throw new ArgumentNullException("CsvWrapperError: csvZipper is null");
                }
            }

            _commonRepository = commonRepository;
            _csvHelper = csvHelper;
            _csvZipper = csvZipper;
        }


        public byte[] Export()
        {
            /*return _csvZipper.Zip(new List<CsvFile>
            {
                TaskExportAsync<Entrant>().Result,
                TaskExportAsync<Departament>().Result
            });*/

            return _csvZipper.Zip(new List<CsvFile>
            {
                _csvHelper.Export(_commonRepository.GetAll<Entrant>()),
                _csvHelper.Export(_commonRepository.GetAll<Departament>()),
                _csvHelper.Export(_commonRepository.GetAll<Professor>()),
                _csvHelper.Export(_commonRepository.GetAll<Result>()),
                _csvHelper.Export(_commonRepository.GetAll<Schedule>()),
                _csvHelper.Export(_commonRepository.GetAll<Specialization>()),
                _csvHelper.Export(_commonRepository.GetAll<Subject>())
            });
        }

        private async Task<CsvFile> TaskExportAsync<T>() where T : BaseEntity
        {
            return await Task.Run<CsvFile>(() => _csvHelper.Export(_commonRepository.GetAll<T>()));
        }

        


        public void Import(byte[] zipContent)
        {
            var items = _csvZipper.Unzip(zipContent);
            foreach (var item in items)
            {
                var str = Format(AssemblyName,item.FileName.Split('.')[0]);
                var type = Type.GetType(str);

                var method = typeof(CsvHelper).GetMethod("Import");
                var generic = method.MakeGenericMethod(type);
                var objects = generic.Invoke(_csvHelper, new object[] {item });

                method = typeof(CommonRepository).GetMethod("AddOrUpdate");
                generic = method.MakeGenericMethod(type);
                generic.Invoke(_commonRepository, new object[] { objects});

            }
        }
    }
}