using com.b_velop.coffee_O_mat.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.coffee_O_mat.Persistence.Context
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
        {
        }

        public DbSet<Brew> Brews { get; set; }
    }
}