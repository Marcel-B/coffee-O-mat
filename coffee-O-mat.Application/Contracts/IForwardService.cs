using System.Threading.Tasks;

namespace com.b_velop.coffee_O_mat.Application.Contracts
{
    public interface IForwardService
    {
        Task Send(Domain.Models.Brew brew);

    }
}