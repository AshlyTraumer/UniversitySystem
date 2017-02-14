namespace AbstractFactory.Proxy
{
    public class GeneralEnter : Person
    {
        public GeneralEnter(string name, bool permit)
        {
            Name = name;
            IsPermit = permit;
        }

        public override string GetEnterByPermission()
        {
            return "Success";
        }
    }
}
