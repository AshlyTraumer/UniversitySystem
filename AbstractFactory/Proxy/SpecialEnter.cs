namespace AbstractFactory.Proxy
{
    public class SpecialEnter : Person
    {
        public SpecialEnter(string name, bool permit)
        {
            Name = name;
            IsPermit = permit;
        }

        public override string GetEnterByPermission()
        {
            // Если есть разрешение, то осуществляем проход, иначе провал
            return IsPermit ? GetEnterByPermission() : "Fail";
        }
    }
}
