using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Heroes
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero?> GetByIdAsync(int id);
        Task<Hero> AddAsync(Hero hero);
        Task UpdateAsync(Hero hero);
        Task DeleteAsync(int id);
        Task UpsertAsync(Hero hero);
    }
}
