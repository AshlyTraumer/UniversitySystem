using System.IO;

namespace AbstractFactory.Adapter
{
    class FileWriter : IFileWriter
    {
        private readonly string _fileName;        

        public FileWriter(string fileName)
        {
            _fileName = fileName;
            
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public void ToFile(string content)
        {
            using (var stream = new StreamWriter(_fileName))
            {
                stream.Write(content);
            }
        }
    }
}
