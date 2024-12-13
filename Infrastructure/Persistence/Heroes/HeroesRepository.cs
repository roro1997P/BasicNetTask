using Domain.Heroes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Heroes
{
    public class HeroesRepository : IHeroesRepository
    {
        private readonly AppDbContext _dbContext;

        public HeroesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hero> AddAsync(Hero hero)
        {
            var entity = await _dbContext.Heroes.AddAsync(hero);
            await _dbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var hero = await GetByIdAsync(id);

            if (hero != null)
            {
                _dbContext.Heroes.Remove(hero);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _dbContext.Heroes.ToListAsync();
        }

        public async Task<Hero?> GetByIdAsync(int id)
        {
            var hero = await _dbContext.Heroes.FindAsync(id);
            return hero;
        }

        public async Task UpdateAsync(Hero hero)
        {
            _dbContext.Heroes.Update(hero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpsertAsync(Hero hero)
        {
            var existingHero = await GetByIdAsync(hero.Id);

            if (existingHero != null)
            {
                existingHero.Update(hero.Name, hero.Description, hero.Thumbnail, hero.ResourceURI);
                _dbContext.Heroes.Update(existingHero);
            }
            else
            {
                await _dbContext.Heroes.AddAsync(hero);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
