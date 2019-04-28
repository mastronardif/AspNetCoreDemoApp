using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;

namespace AspNetCoreDemoApp.Services.MailBee
{
    public class LocalMailBeeService : IMailBeeService
    {
        public void GetUrl(string url)
        {
            Console.WriteLine(value: $"{url} GetUrl : IMailBeeService");
        }

        public async Task<string> PausePrintAsync()
        {
            DateTime t1 = DateTime.Now;
            
            Console.WriteLine($"\tPausePrintAsync 1: {DateTime.Now}");
            await Task.Delay(10000);            
            Console.WriteLine("\tPausePrintAsync(): Hello ");
            Console.WriteLine($"\tPausePrintAsync 2: {DateTime.Now}");
            DateTime t2 = DateTime.Now;
            return ($"\tPausePrintAsync : {t1} - {t2}");
        }

        public async Task<string> GetDataAsync()
        {

            string baseUrl = "http://joeschedule.com";
            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    Console.WriteLine(data);                    
                }
                return data;
            }
        }

        public void Send(string sub, string msg)
        {
            Debug.Write("LocalMailBeeService : IMailBeeService asdfasdfasdfasdf");
            Console.WriteLine(value: $"{sub}\n {msg} LocalMailBeeService : IMailBeeService");
        }
    }
}
