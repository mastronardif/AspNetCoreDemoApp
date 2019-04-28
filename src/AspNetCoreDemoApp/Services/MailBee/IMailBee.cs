using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Services.MailBee
{
public interface IMailBeeService
{
    void GetUrl(string url);
    Task<string>  GetDataAsync();
    void Send(string sub, string msg);
    Task<string> PausePrintAsync();
}

}