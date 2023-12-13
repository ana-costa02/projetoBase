using HelperStockBeta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HelperStockBeta.Application.DTOs;

namespace HelperStockBeta.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		public readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
		{
			var products = await _productService.GetProducts();
			if (products == null)
			{
				return NotFound("Product not found");
			}

			return Ok(products);
		}

		[HttpGet("{id:int}", Name = "GetProduct")]
		public async Task<ActionResult<ProductDTO>> Get(int id)
		{
			var product = await _productService.GetById(id);

			if (product == null)
			{
				return NotFound("Product not found");
			}

			return Ok(product);
		}

		[HttpGet]
		[Route("GetByCategory/{categoryId:int}")]
		public async Task<ActionResult<ProductDTO>> GetProductCategory(int categoryId)
		{
			var products = await _productService.GetProductCategory(categoryId);
			if (products == null)
			{
				return NotFound("Product not found");
			}

			return Ok(products);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
			{
			if (productDto == null)
				{
				return BadRequest("Invalid Body Data");
			}

			await _productService.Add(productDto);

			return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
		}

			[HttpPut]
			public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
			{
				if (id != productDto.Id)
				{
					return BadRequest("Id not verificated");
				}

				if (productDto == null)
				{
					return BadRequest("DTO inspec fail");
				}

				await _productService.Update(productDto);

				return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
			}

			[HttpDelete("{id:int}")]
			public async Task<ActionResult> Delete(int id)
			{
				var product = await _productService.GetById(id);

				if (product == null)
				{
					return NotFound("Product not found");
				}

				await _productService.Remove(id);

				return Ok("Product removed");
			}
	}
}
