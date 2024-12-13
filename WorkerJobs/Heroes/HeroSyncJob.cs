using Application.Heroes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerJobs.Heroes
{
    public class HeroSyncJob
    {
        private readonly SyncHeroesUseCase _syncHeroesUseCase;
        private readonly ILogger<HeroSyncJob> _logger;

        public HeroSyncJob(SyncHeroesUseCase syncHeroesUseCase, ILogger<HeroSyncJob> logger)
        {
            _syncHeroesUseCase = syncHeroesUseCase;
            _logger = logger;
        }

        public async Task Execute()
        {
            _logger.LogInformation("Starting HeroSyncJob at {Time}", DateTimeOffset.Now);

            try
            {
                await _syncHeroesUseCase.ExecuteAsync(null);
                _logger.LogInformation("HeroSyncJob completed succesfully at {Time}", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred in HeroSyncJob at {Time}", DateTimeOffset.Now);
            }
            
        }
    }
}
