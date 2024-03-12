using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShopServer.Repositories;
using MobileShopShared.Models;
using MobileShopShared.Responses;

namespace MobileShopServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategory categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await categoryService.GetAllCategories();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddCategory(Category model)
        {
            if (model is null) return BadRequest("Model is Null");
            var response = await categoryService.AddCategory(model);
            return Ok(response);
        }
    }
}
