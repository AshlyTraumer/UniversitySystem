using System;
using System.Collections.Generic;
using ClassLibrary;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class CsvWrapper : ICsvWrapper
    {
        private readonly ICommonRepository _commonRepository;
        private readonly ICsvHelper _csvHelper;
        private readonly ICsvZipper _csvZipper;

        //TODO throw argumentnullexception
        public CsvWrapper(ICommonRepository commonRepository, ICsvHelper csvHelper, ICsvZipper csvZipper)
        {
            if (commonRepository == null || csvHelper == null || csvZipper == null)
                throw new ArgumentNullException();

            _commonRepository = commonRepository;
            _csvHelper = csvHelper;
            _csvZipper = csvZipper;
        }


        public byte[] Export()
        {
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

        public void Import(byte[] zipContent)
        {
            throw new NotImplementedException();
        }
    }
}