using ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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
                .AddSingleton<ISecretRevealer, SecretRevealer>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();

            // Get the service you need - DI will handle any dependencies - in this case IOptions<SecretStuff>
            var revealer = serviceProvider.GetService<ISecretRevealer>();

            revealer.Reveal();

            Console.ReadKey();


            const string accountSid = "ACe1797bb4dd64e533422f6fe98840e51c";
            const string authToken = "xxx";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Let's grab lunch at Milliways tomorrow!xxx",
                from: new Twilio.Types.PhoneNumber("+14157920678"),
                //mediaUrl: Promoter.ListOfOne(new Uri("http://www.example.com/cheeseburger.png")),
                to: new Twilio.Types.PhoneNumber("+14082341385"),
                //statusCallback: new Uri("http://requestbin.fullcontact.com/r0h0mfr0"),
                statusCallback: new Uri("http://519f04fe.ngrok.io/TwilioSms")
            );

            Console.WriteLine(message.Sid);


        }
    }
}
