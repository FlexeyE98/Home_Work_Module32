using WebApplication3.Models.db;

namespace WebApplication3
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();

    }
}
