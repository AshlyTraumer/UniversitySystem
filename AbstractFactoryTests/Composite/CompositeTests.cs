using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Composite.Tests
{
    [TestClass()]
    public class CompositeTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var rootCompany = new Composite("Root", 120);

            rootCompany.Add(new ChildCompany("Leaf1", 50));

            var leaf = new Composite("Leaf2", 52);
            leaf.Add(new ChildCompany("LeafLeaf1", 20));
            leaf.Add(new ChildCompany("LeafLeaf2",12));

            rootCompany.Add(leaf);

            var count = rootCompany.GetAllCount();
            Assert.IsTrue(count == 254);
        }
    }
}