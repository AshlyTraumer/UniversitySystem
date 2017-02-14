using AbstractFactory.Template;

namespace AbstractFactory.Prototype
{
    public class HeaderClone : IClone
    {
        private string _header;

        public void SetHeader()
        {
            _header = Headers.EnHello;
        }

        public string GetHeader()
        {
            return _header;
        }

        public IClone CustomClone()
        {
            return  (IClone) MemberwiseClone();
        }
    }
}
