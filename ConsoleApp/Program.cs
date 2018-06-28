using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://www.twilio.com/docs/sms/send-messages
            // https://www.twilio.com/docs/libraries/csharp

            // Find your Account Sid and Token at twilio.com/console
            //const string accountSid = "ACe1797bb4dd64e533422f6fe98840e51c";
            //const string authToken = "your_auth_token";

            const string accountSid = "ACe1797bb4dd64e533422f6fe98840e51c";
            const string authToken = "acb129845d3c5f65b0d12c30c0c5204e";

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
