using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public enum SmsDelieveryStatus
    {
        New = 1,
        PendingDeliver = 2,
        Delivered = 3,
        Failed = 4
    }

    public class SmsModel
    {
        public string SmsPhoneNumber { get; set; }
        public string MessageBody { get; set; }
        public DateTime SmsSentDateTime { get; set; }
        public string Sid { get; set; }
        public SmsDelieveryStatus DeliveryStatus { get; set; }
    }
}
