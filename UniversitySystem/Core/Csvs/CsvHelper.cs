using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using ClassLibrary;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class CsvHelper : ICsvHelper
    {
        private readonly CultureInfo _cultureInfo = Thread.CurrentThread.CurrentCulture;
        private const string Format = "dd.MM.yyyy";

        public CsvFile Export<T>(List<T> items)
        {
            var strList = new List<string>();
            var tType = typeof(T);
            
            var tProp = tType.GetProperties()
                .Where(q => (q.GetMethod.ReturnType.Name != typeof(ICollection<>).Name) &&
                            (q.GetMethod.ReturnType.BaseType?.Name != typeof(BaseEntity).Name))
                .ToList();

            strList.Add(string.Join(";", tProp.Select(q => q.Name)));

            foreach (var item in items)
            {
                var list = new List<string>();

                foreach (var tPropSome in tProp)
                    list.Add(tPropSome.PropertyType == typeof(DateTime)
                        ? ((DateTime)tPropSome.GetValue(item, null)).ToString(Format, _cultureInfo)
                        : tPropSome.GetValue(item).ToString());

                strList.Add(string.Join(";", list));
            }

            return new CsvFile(tType.Name + ".csv", strList);
        }

        public List<T> Import<T>(CsvFile csvFile)
        {
            var list = new List<T>();
            var csvStrings = csvFile.CsvStrings;
            var tType = typeof(T);
            
            var tProp = tType.GetProperties()
                .Where(q => (q.GetMethod.ReturnType.Name != typeof(ICollection<>).Name) &&
                            (q.GetMethod.ReturnType.BaseType?.Name != typeof(BaseEntity).Name))
                .ToList();

            if (!tProp.Select(q => q.Name)
                .ToList()
                .SequenceEqual(csvStrings[0].Remove(csvStrings[0].Length - 1, 1)
                                                    .Split(';')
                                                    .ToList())) 

                throw new FileParamException("Несоответствие таблиц");
        
            for (var index = 1; index < csvStrings.Count; index++)
            {
                var str = csvStrings[index].Last() == '\r' 
                    ? csvStrings[index].Remove(csvStrings[index].Length - 1,1) 
                    : csvStrings[index];

                var properties = str.Split(';').ToList();

                var newObject = (T) Activator.CreateInstance(tType);

                if (tProp.Count != properties.Count)
                    throw new FileParamException("Файл не соответствует базе данных");

                for (var i = 0; i < properties.Count; i++)
                {
                    tProp[i].SetValue(newObject,
                        tProp[i].PropertyType.Name != typeof(DateTime).Name
                            ? Convert.ChangeType(properties[i], tProp[i].PropertyType)
                            : DateTime.ParseExact(properties[i], Format, _cultureInfo));
                }

                list.Add(newObject);
            }

            return list;
        }
    }
}