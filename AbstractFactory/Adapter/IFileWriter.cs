namespace AbstractFactory.Adapter
{
    interface IFileWriter
    {
        string GetFileName();
        void ToFile(string content);
    }
}
