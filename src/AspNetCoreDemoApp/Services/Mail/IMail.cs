using System.Collections.Generic;

namespace AspNetCoreDemoApp.Services.Mail
{
public interface IMailService
{
    void Send(string sub, string msg);
}

}