using System.Linq;
using System.Threading.Tasks;
using com.b_velop.coffee_O_mat.Domain.Models;

namespace coffee_O_mat.Data.Contracts
{
    public interface ICoffeeOMatRepository
    {
        Brew AddBrew(Brew brew);
        IQueryable<Brew> Brews();
        Task<int> SaveChanges();
    }
}