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
		 
		//readonly ILogger _logger22 = Log.ForContext<ValuesController>();

		public ValuesController(IConfiguration configuration, ILogger<ValuesController> logger)
    	{
        	this.conf = configuration;
			_logger = logger;
			
			//Console.WriteLine($"ctor  _logger = {_logger}");
    	}

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			//Console.WriteLine($"get  Log = {Log}");
			this._logger.LogInformation("Index was called XXXXXXXXXXXXXXXXXXXXXX");
            _logger.LogWarning("XXXXXXXXXXX Controller LogWarning");
            _logger.LogDebug("XXXXXXXXXXXXXX Controller   LogDebug");
            _logger.LogError("XXXXXXXXXXX Controller   LogError");
			
			Console.WriteLine($"XXXXXXXXXXXXXXX   {conf["name"]}");
			//_logger.LogInformation("GetById({ID}) NOT FOUND", 123);			
 			//_logger.LogError("It broke :(");			
			//_logger.LogDebug( "DDDDDDDD Debug  AspNet.Core");
			
       Console.WriteLine($"_logger = {_logger}");

		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());			
			return new[] { $"{conf["name"]} value1 9:59 PM 4/25/19", "value2 UK buddy" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}