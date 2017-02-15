using System;
using System.Collections.Generic;

namespace AbstractFactory.Composite
{
    //public abstract class Departament
    //{
    //    protected string name;

    //    public Departament(string name)
    //    {
    //        this.name = name;
    //    }

    //    public abstract void Display();
    //    public abstract void Add(Departament c);
    //    public abstract void Remove(Departament c);
    //}
    //public class Composite : Departament
    //{
    //    List<Departament> childDepartaments = new List<Departament>();

    //    public Composite(string name)
    //    : base(name)
    //    { }
    
    //    public override void Add(Departament departament)
    //    {
    //        childDepartaments.Add(departament);
    //    }

    //    public override void Remove(Departament departament)
    //    {
    //        childDepartaments.Remove(departament);
    //    }

    //    public override void Display()
    //    {
    //        Console.WriteLine(name);

    //        foreach (var departament in childDepartaments)
    //        {
    //            departament.Display();
    //        }
    //    }
    //}
    /*public class Leaf : Departament
    {
        public Leaf(string name)
        : base(name)
        { }

        public override void Display()
        {
            Console.WriteLine(name);
        }

        public override void Add(Departament departament)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Departament departament)
        {
            throw new NotImplementedException();
        }
    }*/
}
