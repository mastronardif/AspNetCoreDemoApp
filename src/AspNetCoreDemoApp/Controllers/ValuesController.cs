using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AspNetCoreDemoApp.Services.Mail;
using AspNetCoreDemoApp.Services.MailBee;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		IConfiguration _conf;
		readonly ILogger  _logger;
		private IMailService _mailService;

        private IMailBeeService _mailBeeService { get; }

        public ValuesController(IConfiguration configuration, ILogger<ValuesController> logger, IMailService mailService,
								IMailBeeService mailBeeService)
    	{
        	this._conf = configuration;
			_logger = logger;
			_mailService = mailService;
            _mailBeeService = mailBeeService;
        }

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			//Console.WriteLine($"get  Log = {Log}");
			this._logger.LogInformation("api/values was called XXXXXXXXXXXXXXXXXXXXXX");
            //_logger.LogWarning("XXXXXXXXXXX Controller LogWarning");
            //_logger.LogDebug("XXXXXXXXXXXXXX Controller   LogDebug");
            //_logger.LogError("XXXXXXXXXXX Controller   LogError");
			
			Console.WriteLine($"XXXXXXXXXXXXXXX   {_conf["name"]}");		

		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());	

			Console.WriteLine($"calling PausePrintAsync{DateTime.Now}");
			
			// mail test			
			//_mailService.Send("the subject", "the msg");		
			_mailBeeService.GetDataAsync();	
			
			//string results = _mailBeeService.GetData();	
			//Console.WriteLine(results);
			//_mailBeeService.PausePrintAsync();

			//string asyncString = await _mailBeeService.PausePrintAsync();
			// Task<string> task = Task.Run(async () => await _mailBeeService.PausePrintAsync()
			// );
    		// string asyncString = task.Result;
			// Console.WriteLine($"asyncString= {asyncString}");

			Console.WriteLine($"ret     PausePrintAsync{DateTime.Now}");

			return new[] { $"{_conf["name"]} value1 10:48 PM 4/27/19", $"value2 {DateTime.Now}  logging(file, mongo, cloud),  todo: IEmail" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}