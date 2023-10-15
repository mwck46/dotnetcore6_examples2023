using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Diagnostics;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStoreRepository _repository;
        public int PageSize = 4;

        public HomeController(ILogger<HomeController> logger, IStoreRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        public IActionResult Index(int productPage = 1)
        {
            return View(
                _repository.Products
                .OrderBy(p=>p.ProductID)
                .Skip((productPage-1)*PageSize)
                .Take(PageSize)
                );
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