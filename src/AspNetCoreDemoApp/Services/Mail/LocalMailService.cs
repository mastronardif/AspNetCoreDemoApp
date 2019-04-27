using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AspNetCoreDemoApp.Services.Mail
{
    public class LocalMailService : IMailService
    {     
        public void Send(string sub, string msg)
        {
            Debug.Write("MailService asdfasdfasdfasdf");
            Console.WriteLine(value: $"{sub}\n {msg} LocalMailService LocalMailService LocalMailService");
        }
    }
}
