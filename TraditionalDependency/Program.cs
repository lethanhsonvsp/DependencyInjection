using System;

namespace TraditionalDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassC objectC = new ClassC();
            ClassB objectB = new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();
        }
    }

    class ClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB
    {
        ClassC c_dependency;

        public ClassB(ClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        ClassB b_dependency;

        public ClassA(ClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
}
