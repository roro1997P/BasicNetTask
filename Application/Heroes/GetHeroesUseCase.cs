using Domain.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Heroes
{
    public class GetHeroesUseCase : IUseCase<object, IEnumerable<Hero>>
    {
        private readonly IHeroesRepository _repository;

        public GetHeroesUseCase(IHeroesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Hero>> ExecuteAsync(object request)
        {
            return await _repository.GetAllAsync();
        }
    }
}
