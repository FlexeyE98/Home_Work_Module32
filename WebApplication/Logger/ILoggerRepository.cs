using WebApplication3.Models.db;

namespace WebApplication3.Logger
{
    public interface ILoggerRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
