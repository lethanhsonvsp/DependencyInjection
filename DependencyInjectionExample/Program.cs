using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample
{
    public interface IHorn
    {
        void Beep();
    }

    public class HeavyHorn : IHorn
    {
        public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    }

    public class Car
    {
        IHorn horn;
        public Car(IHorn horn) => this.horn = horn;
        public void Beep() => horn.Beep();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IHorn, HeavyHorn>();
            services.AddSingleton<Car>();
            var provider = services.BuildServiceProvider();

            var car = provider.GetService<Car>();
            if (car != null)
            {
                car.Beep();
            }
        }
    }
}
