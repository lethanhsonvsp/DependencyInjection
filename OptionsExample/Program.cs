using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OptionsExample
{
    public class MyServiceOptions
    {
        public string? Data1 { get; set; }
        public int Data2 { get; set; }
    }

    public class MyService
    {
        MyServiceOptions options;
        public MyService(IOptions<MyServiceOptions> options) => this.options = options.Value;
        public void PrintData() => Console.WriteLine($"{options.Data1} {options.Data2}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.Configure<MyServiceOptions>(options =>
            {
                options.Data1 = "Hello";
                options.Data2 = 2024;
            });
            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();
            var myService = provider.GetService<MyService>();
            if (myService != null)
            {
                myService.PrintData();

            }
        }
    }
}
