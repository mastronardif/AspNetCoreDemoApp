using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AspNetCoreDemoApp.Services.Mail
{
    public class CloudMailService : IMailService
    {     
        public void Send(string sub, string msg)
        {
            Debug.Write("MailService asdfasdfasdfasdf");
            Console.WriteLine(value: $"{sub}\n {msg} CloudMailService CloudMailService CloudMailService");
        }
    }
}
