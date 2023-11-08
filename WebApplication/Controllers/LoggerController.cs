using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Logger;
using WebApplication3.Models;
using WebApplication3.Models.db;

namespace WebApplication3.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;

        public LoggerController(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logs()
        {
            var request = await _loggerRepository.GetRequests();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logs(Request request)
        {
            await _loggerRepository.AddRequest(request);
            return View(request);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
