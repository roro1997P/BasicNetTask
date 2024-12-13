using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Heroes
{
    public class SyncHeroesUseCase : IUseCase<object, object>
    {
        private readonly FetchHeroesUseCase _fetchHeroesUseCase;
        private readonly UpsertHeroUseCase _upsertHeroUseCase;

        public SyncHeroesUseCase(FetchHeroesUseCase fetchHeroesUseCase, UpsertHeroUseCase upsertHeroUseCase)
        {
            _fetchHeroesUseCase = fetchHeroesUseCase;
            _upsertHeroUseCase = upsertHeroUseCase;
        }

        public async Task<object> ExecuteAsync(object request)
        {
            // Get data from api
            var heroes = await _fetchHeroesUseCase.ExecuteAsync(request);

            // Upsert data in db
            await _upsertHeroUseCase.ExecuteAsync(heroes);

            return null;
        }
    }
}
