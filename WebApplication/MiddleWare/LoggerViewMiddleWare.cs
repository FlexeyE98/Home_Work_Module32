using WebApplication3.Logger;
using WebApplication3.Models.db;

namespace WebApplication3.MiddleWare
{
    public class LoggerViewMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment env;
        private readonly ILoggerRepository _repository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggerViewMiddleWare(RequestDelegate next, IWebHostEnvironment env, ILoggerRepository repository)
        {
            _next = next;
            this.env = env;
            _repository = repository;

        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)

            var request = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = logMessage
            };

            await _repository.AddRequest(request);

            await _next.Invoke(context);

        }
    }
}
