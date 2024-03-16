using Crafts_ASPNET.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;


namespace Crafts_ASPNET.Services
{
    public class JsonFileProductService
    {
        // constructor
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment, ILogger<JsonFileProductService> logger)
        {
            WebHostEnvironment = webHostEnvironment;
			_logger = logger;
		}

        public IWebHostEnvironment WebHostEnvironment { get; }
		private readonly ILogger<JsonFileProductService> _logger;

		private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

		public IEnumerable<Product> GetProducts()
		{
			try
			{
				using (var jsonFileReader = File.OpenText(JsonFileName))
				{
					return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
						new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true
						});
				}
			}
			catch (Exception ex)
			{
				// Log the exception
				_logger.LogError(ex, "Error occurred while deserializing JSON data");
				throw; // Rethrow the exception
			}
		}
	}
}
