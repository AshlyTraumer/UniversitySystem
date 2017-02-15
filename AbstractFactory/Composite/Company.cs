namespace AbstractFactory.Composite
{
    public abstract  class Company
    {
        protected string _title;
        protected int _count;

        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract int GetAllCount();
    }
}
