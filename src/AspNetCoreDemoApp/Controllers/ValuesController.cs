using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		IConfiguration conf;
		readonly ILogger  _logger;

		public ValuesController(IConfiguration configuration, ILogger<ValuesController> logger)
    	{
        	this.conf = configuration;
			_logger = logger;
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
			
			Console.WriteLine($"XXXXXXXXXXXXXXX   {conf["name"]}");		

		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());			
			return new[] { $"{conf["name"]} value1 10:48 PM 4/27/19", "value2 logging buddy" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}