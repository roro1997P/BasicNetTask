using Application.Heroes;
using Domain.Heroes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly GetHeroesUseCase _getHeroesUseCase;

        public HeroesController(GetHeroesUseCase getHeroesUseCase)
        {
            _getHeroesUseCase = getHeroesUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetAllProducts()
        {
            var heroes = await _getHeroesUseCase.ExecuteAsync(null);
            return Ok(heroes);
        }
    }
}
