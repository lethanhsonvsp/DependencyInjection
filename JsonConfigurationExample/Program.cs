using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace JsonConfigurationExample
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

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configurationRoot = configBuilder.Build();
            services.AddOptions();
            services.Configure<MyServiceOptions>(configurationRoot.GetSection("MyServiceOptions"));

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
