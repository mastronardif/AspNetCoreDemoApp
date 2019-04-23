using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		IConfiguration conf;

		public ValuesController(IConfiguration configuration)
    	{
        	this.conf = configuration;
    	}

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			Console.WriteLine($"XXXXXXXXXXXXXXX   {conf["name"]}");

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