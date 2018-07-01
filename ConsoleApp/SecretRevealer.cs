using ConsoleApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface ISecretRevealer
    {
        void Reveal();
    }

    public class SecretRevealer : ISecretRevealer
    {
        private readonly SecretStuff _secrets;
        public SecretRevealer(IOptions<SecretStuff> secrets)
        {
            _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
        }

        public void Reveal()
        {
            //I can now use my mapped secrets below.
            Console.WriteLine($"TwilioAccountSid: {_secrets.TwilioAccountSid}");
            Console.WriteLine($"TwilioAuthToken: {_secrets.TwilioAuthToken}");
        }
    }
}
