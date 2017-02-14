using AbstractFactory.Template;

namespace AbstractFactory.Prototype
{
    public class ContentClone : IClone
    {
        private string _content;

        public void SetHeader()
        {
            _content = Contents.EnContent;
        }

        public string GetContent()
        {
            return _content;
        }

        public IClone CustomClone()
        {
            return (IClone) MemberwiseClone();
        }
    }
}
