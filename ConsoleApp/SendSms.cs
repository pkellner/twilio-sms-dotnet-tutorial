using ConsoleApp.Models;
using Microsoft.Extensions.Options;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ConsoleApp
{
    public class SendSms : ISendSms
    {
     
        private readonly SecretStuff _secrets;
        public SendSms(IOptions<SecretStuff> secrets)
        {
            _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
           
        }

        
        public string Send(string fromNumber, string toNumber, string messageBody)
        {
            TwilioClient.Init(_secrets.TwilioAccountSid, _secrets.TwilioAuthToken);

            var message = MessageResource.Create(
                body: messageBody,
                from: new Twilio.Types.PhoneNumber(fromNumber),
                //mediaUrl: Promoter.ListOfOne(new Uri("http://www.example.com/cheeseburger.png")),
                to: new Twilio.Types.PhoneNumber(toNumber),
                //statusCallback: new Uri("http://requestbin.fullcontact.com/r0h0mfr0"),
                statusCallback: new Uri("http://519f04fe.ngrok.io/TwilioSms")
            );

            return message.Sid;
        }
    }
}