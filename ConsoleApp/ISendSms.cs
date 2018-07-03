using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface ISendSms
    {
        string Send(string fromNumber,string toNumber,string bodyMessage);
    }
}
