using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TESTBOK.Models;
using TESTBOK.ViewModels;

namespace TESTBOK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBctx _context;

        public HomeController(ILogger<HomeController> logger, DBctx context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {

            return View();
        }
        //public IActionResult Overview()
        //{
        //    var viewModel = new UnitResViewModel();
        //    var unit = _context.Units.ToList();
        //    IEnumerable<Unit> units = unit;
        //    viewModel.UnitsList = units;

        //    return View(viewModel);
        //}

        public IActionResult Search()
        {
            var viewModel = new UnitResViewModel();
            var unit = _context.Units.ToList();
            IEnumerable<Unit> units = unit;
            viewModel.UnitsList = units;

            return View(viewModel);
        }

        public IActionResult Information()
        {
            return View();
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
