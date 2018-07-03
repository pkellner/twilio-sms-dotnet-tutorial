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
            // https://www.twilio.com/docs/sms/send-messages
            // https://www.twilio.com/docs/libraries/csharp

            // Find your Account Sid and Token at twilio.com/console
            //const string accountSid = "ACe17xxxxxx";
            //const string authToken = "your_auth_token";

            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            //Map the implementations of your classes here ready for DI
            services
                .Configure<SecretStuff>(Configuration.GetSection(nameof(SecretStuff)))
                .AddOptions()
                .AddLogging()
                .AddSingleton<ISendSms, SendSms>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();

            var sendSms = serviceProvider.GetService<ISendSms>();
            var result = sendSms.Send("+14157920678", "+14082341385", "Faxing Using Secrets");
            Console.WriteLine("sendSms returned:" + result);
        }
    }
}
