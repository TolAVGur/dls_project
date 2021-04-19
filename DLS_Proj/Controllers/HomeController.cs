using DLS_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using BusinesLayer.Repositories;
using PresentationLayer;

namespace DLS_Proj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private EFDBContext _context;
        private DataManager _dataManager;
        private ServicesManager _serviceManager;



        public HomeController(ILogger<HomeController> logger, /*EFDBContext context,*/ DataManager dataManager)
        {
            _logger = logger;
            //_context = context;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
        }

        public IActionResult Index()
        {
            //var dirs = _context.Directories.Include(x => x.Materials).ToList();
            //var dirs = _dataManager.DirRepos.GetAllDirectories(true);
            var dirs = _serviceManager.DirService.TransitDirectoriesToView();
            return View(dirs);
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
