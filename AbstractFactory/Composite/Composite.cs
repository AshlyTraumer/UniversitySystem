using System.Collections.Generic;

namespace AbstractFactory.Composite
{
    public class Composite : Company
    {
        private readonly List<Company> _childCompanies;

        public Composite(string title, int count)
        {
            _childCompanies = new List<Company>();
            _title = title;
            _count = count;
        }
        
        public override void Add(Company company)
        {
            _childCompanies.Add(company);
        }

        public override void Remove(Company company)
        {
            _childCompanies.Remove(company);
        }

        public override int GetAllCount()
        {
            foreach (var company in _childCompanies)
            {
                _count += company.GetAllCount();
            }

            return _count;
        }
    }

   
}
