using Microsoft.EntityFrameworkCore;
using WebApplication3.MiddleWare;
using WebApplication3.Models.db;

namespace WebApplication3.Logger
{
    public class LoggerRepository : ILoggerRepository

    {
        private readonly BlogContext _blogContext;


        public LoggerRepository(BlogContext blogContext) 
        {
            _blogContext = blogContext;


        
        }
        public async Task AddRequest(Request request)
        {

            var entry = _blogContext.Entry(request);
            if (entry.State == EntityState.Detached)
                await _blogContext.Requests.AddAsync(request);

            // Сохранение изенений
            await _blogContext.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
           return await _blogContext.Requests.ToArrayAsync();
        }
    }
}
