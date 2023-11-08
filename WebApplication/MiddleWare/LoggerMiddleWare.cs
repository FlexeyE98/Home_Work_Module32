using WebApplication3.Logger;
using WebApplication3.Models.db;

namespace WebApplication3.MiddleWare
{
    public class LoggerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment env;
        private readonly IBlogRepository _repository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggerMiddleWare(RequestDelegate next, IWebHostEnvironment env, IBlogRepository repository)
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
            string logFilePath = Path.Combine(env.ContentRootPath, "Logger", "logger.txt");

            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            await File.AppendAllTextAsync(logFilePath, logMessage);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);

        }
    }
}
