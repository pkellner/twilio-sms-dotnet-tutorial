using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class TwilioSmsModel
    {
        [Key]
        public string SmsSid { get; set; }
        public string ApiVersion { get; set; }
        public string AccountSid {get;set;}
        public string To { get; set; }
        public string MessageStatus { get; set; }
        public string MessageSid { get; set; }
        public string SmsStatus { get; set; }
    }
}


//FORM/POST PARAMETERS
//SmsSid: SM72e9c29bb37f40a69c818c3151a01632

//ApiVersion: 2010-04-01

//AccountSid: ACe1797bb4dd64e533422f6fe98840e51c

//To: +14082341385

//MessageStatus: delivered

//From: +14157920678

//MessageSid: SM72e9c29bb37f40a69c818c3151a01632

//SmsStatus: delivered