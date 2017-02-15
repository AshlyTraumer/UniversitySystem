using System;

namespace AbstractFactory.Composite
{
    public class ChildCompany : Company
    {
        public ChildCompany(string title, int count)
        {
            _title = title;
            _count = count;
        }

        public override void Add(Company c)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Company c)
        {
            throw new NotImplementedException();
        }

        public override int GetAllCount()
        {
            return _count;
        }
    }
}