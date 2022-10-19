using ErickEspinosa.Redis.WebApi.Cache;
using ErickEspinosa.Redis.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErickEspinosa.Redis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Cached(600)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(FakeRepository.GetProducts());

        [Cached(600)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = FakeRepository.GetProduct(id);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
