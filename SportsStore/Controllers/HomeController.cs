using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Diagnostics;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStoreRepository _repository;

        public HomeController(ILogger<HomeController> logger, IStoreRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}