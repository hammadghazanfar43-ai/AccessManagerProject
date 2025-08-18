using Model;


namespace AccessManager.Core.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserAccount user);
        UserAccount? GetUserByUsername(string username);
        UserAccount? GetUserByEmail(string email);
        void UpdateUser(UserAccount user);
        bool SaveChanges();
    }
}
