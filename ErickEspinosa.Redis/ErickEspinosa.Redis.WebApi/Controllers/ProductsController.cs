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
        {
            return Ok(FakeRepository.GetProducts());
        }

        [Cached(600)]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(FakeRepository.GetProducts().First(x => x.Id == id));
        }
    }
}
