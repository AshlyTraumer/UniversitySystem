using System;
using System.Collections.Generic;

namespace AbstractFactory.LazyInitialization
{
    public class CustomCache
    {
        private Dictionary<int, CustomData> _dictionary;
        public Lazy<Dictionary<int, CustomData>> _lazy = new Lazy<Dictionary<int, CustomData>>();

        public CustomCache()
        {
            _dictionary = new Dictionary<int, CustomData>();
            
        }

        public CustomData GetDataById(int id)
        {
            var tryData = new CustomData();
            if (_dictionary.TryGetValue(id, out tryData))
                return _dictionary[id]; 
                    else
                return new CustomData {Id = id};
        }

        public CustomData GetDataByIdLazy(int id)
        {
            var tryData = new CustomData();

            if (_lazy.Value.TryGetValue(id, out tryData))
                return _lazy.Value[id];
            else
                return new CustomData { Id = id };
        }

        public void Set(CustomData data)
        {
            _dictionary.Add(data.Id, data);
        }
    }
}
