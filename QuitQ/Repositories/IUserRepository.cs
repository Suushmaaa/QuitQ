using System.Threading.Tasks;
using QuitQ.API.Models;

namespace QuitQ.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
