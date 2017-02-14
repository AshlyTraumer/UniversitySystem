namespace AbstractFactory.Proxy
{
    public abstract class Person
    {
        protected string Name;
        protected bool IsPermit;

        public abstract string GetEnterByPermission();
    }
}
