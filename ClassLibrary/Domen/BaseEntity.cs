using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        //TODO Update with reflection
        public void UpdateByImport<T>(T newItem)
        {
            var type = typeof(T);
            var properties = type.GetProperties()
                .Where(q => (q.GetMethod.ReturnType.Name != typeof(ICollection<>).Name) &&
                            (q.GetMethod.ReturnType.BaseType?.Name != typeof(BaseEntity).Name))
                .ToList();

            foreach (var property in properties)
            {
                property.SetValue(this, property.GetValue(newItem));
            }
        }
    }
}