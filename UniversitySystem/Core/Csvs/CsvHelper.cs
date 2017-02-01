using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Core.Csvs
{
    public class CsvHelper : ICsvHelper
    {
        public CsvFile Export<T>(List<T> items)
        {
            var strList = new List<string>();
            var tType = typeof(T);

            var tProp = tType.GetProperties()
                .Where(q => (q.GetMethod.ReturnType.Name != typeof(ICollection<>).Name) && 
                            (q.GetMethod.ReturnType.BaseType?.Name != typeof(BaseEntity).Name))
                .ToList();

            strList.Add(string.Join(";",tProp.Select(q => q.Name)));

            foreach (var item in items)
            {
                //var list = new List<string>();
                //foreach (var tPropSome in tProp)
                //    if (tPropSome.PropertyType == typeof(DateTime))
                //    {
                //        var date = (DateTime) tPropSome.GetValue(item, null);
                //        list.Add(date.ToShortDateString());
                //    }
                //    else
                //    {
                //        list.Add(tPropSome.GetValue(item).ToString());
                //    }
                //strList.Add(string.Join(";",list));    

                strList.Add(string.Join(";", tProp.Select(q => q.GetValue(item))));
            }

            return new CsvFile(tType.Name+".csv",strList); 
        }
    }
}