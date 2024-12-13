using Domain.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Heroes
{
    public class UpsertHeroUseCase : IUseCase<IEnumerable<Hero>, object>
    {
        private readonly IHeroesRepository _repository;

        public UpsertHeroUseCase(IHeroesRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> ExecuteAsync(IEnumerable<Hero> request)
        {
            foreach (var hero in request)
            {
                await _repository.UpsertAsync(hero);
            }

            return null;
        }
    }
}
