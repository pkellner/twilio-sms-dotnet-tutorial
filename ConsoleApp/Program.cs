using ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ConsoleApp
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var devEnvironmentVariable = 
                Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }
            Configuration = builder.Build();
            IServiceCollection services = new ServiceCollection();
            services
                .Configure<SecretStuff>(Configuration.GetSection(nameof(SecretStuff)))
                .AddOptions()
                .AddLogging()
                .AddSingleton<ISendSms, SendSms>()
                .BuildServiceProvider();
            var serviceProvider = services.BuildServiceProvider();

            // Send the Text Message!
            var sendSms = serviceProvider.GetService<ISendSms>();
            var result = sendSms.Send("+14157920678", "+14082341234",
                "Faxing Using Secrets From Mac");
            Console.WriteLine("sendSms returned:" + result);
        }
    }
}
