using System.Linq;
using System.Threading.Tasks;
using coffee_O_mat.Data.Contracts;
using com.b_velop.coffee_O_mat.Domain.Models;
using com.b_velop.coffee_O_mat.Persistence.Context;

namespace coffee_O_mat.Data.Repositories
{
    public class CoffeeOMatRepository : ICoffeeOMatRepository
    {
        private readonly CoffeeContext _context;

        public CoffeeOMatRepository(CoffeeContext context)
        {
            _context = context;
        }
        
        public Brew AddBrew(Brew brew)
        {
            var result = _context.Brews.Add(brew);
            return result.Entity;
        }

        public IQueryable<Brew> Brews()
        {
            return _context.Brews.AsQueryable();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}