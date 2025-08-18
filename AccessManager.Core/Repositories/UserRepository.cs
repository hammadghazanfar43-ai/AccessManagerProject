using AccessManager.Core.Data;
using AccessManager.Core.Interfaces;
using Model;

using System.Linq;

namespace AccessManager.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserAccount user)
        {
            _context.UserAccounts.Add(user);
        }

        public UserAccount? GetUserByUsername(string username)
        {
            return _context.UserAccounts.FirstOrDefault(u => u.UserName == username);
        }

        public UserAccount? GetUserByEmail(string email)
        {
            return _context.UserAccounts.FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(UserAccount user)
        {
            _context.UserAccounts.Update(user);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
