using System.Threading.Tasks;
using QuitQ.API.Models;
using Microsoft.EntityFrameworkCore;

namespace QuitQ.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuitQDbContext _context;

        public UserRepository(QuitQDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
