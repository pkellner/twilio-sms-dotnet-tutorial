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
                to: new Twilio.Types.PhoneNumber(toNumber),
                //statusCallback: new Uri("http://requestbin.net/r/1mlxpv31")
                statusCallback: new Uri("http://d84d97f7.ngrok.io/api/sms")
            );

            return message.Sid;
        }
    }
}