using Crafts_ASPNET.Models;
using Crafts_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crafts_ASPNET.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase

	{
		// Properties
		public JsonFileProductService ProductService { get; }

		// constructor
		public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

		// Get method to get all of the Products
		[HttpGet]
		public IEnumerable<Product> Get()
		{
			return ProductService.GetProducts();
		}

		// [HttpPatch] "[FromBody]"
		[Route("Rate")]
		[HttpGet]
		public ActionResult Get([FromQuery] string ProductId, [FromQuery] int Rating)
		{
			ProductService.AddRating(ProductId, Rating);
			return Ok();
		}
         
    }
}
