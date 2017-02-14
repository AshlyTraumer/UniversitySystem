namespace AbstractFactory.Adapter
{
    public class Adapter : IConsoleWrite
    {
        private readonly FileWriter _writer;
        private readonly string _content;

        public Adapter(string fileName, string content)
        {
            _writer = new FileWriter(fileName);
            _content = content;
        }

        public void Write()
        {
            _writer.ToFile(_content);
        }
    }
}
