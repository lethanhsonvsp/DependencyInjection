using System;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            IClassC objectC = new ClassC();
            IClassB objectB = new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();
        }
    }

    interface IClassB
    {
        void ActionB();
    }

    interface IClassC
    {
        void ActionC();
    }

    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
}
