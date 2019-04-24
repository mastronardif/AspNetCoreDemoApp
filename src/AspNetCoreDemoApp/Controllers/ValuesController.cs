using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		IConfiguration conf;
		private readonly ILogger _logger;

		public ValuesController(IConfiguration configuration, ILogger<ValuesController> logger)
    	{
        	this.conf = configuration;
			_logger = logger;
    	}

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			Console.WriteLine($"XXXXXXXXXXXXXXX   {conf["name"]}");
			_logger.LogWarning("GetById({ID}) NOT FOUND", 123);
       

		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());			
			return new[] { $"{conf["name"]} value1 3:00 PM 4/23/19", "value2 UK buddy" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}