using System.Collections.Generic;

namespace AbstractFactory.Singleton
{
    public sealed class AppConfig
    {
        private static readonly AppConfig _instance = new AppConfig();
        private static Dictionary<string, string> _config;

        private AppConfig()
        {
            
        }

        public static AppConfig GetInstance()
        {
            if (_config == null)
                _config = new Dictionary<string, string>();

           // return _instance ?? (_instance = new AppConfig());
            return _instance;
        }

        public void SetConfig(string key, string value)
        {
            _config.Add(key,value);
        }

        public string GetConfigByKey(string key)
        {
            return _config[key];
        }
    }
}
