using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TESTBOK.Models;
using TESTBOK.ViewModels;

namespace TESTBOK.Controllers
{
    public class OverViewController : Controller
    {
        private readonly ILogger<OverViewController> _logger;
        private readonly DBctx _context;

        public OverViewController(ILogger<OverViewController> logger, DBctx context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: OverViewController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: OverViewController
        public ActionResult Overview()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            var date = DateTime.Now;
            var datum = date.ToString("yyyy-MM-dd");
            var day = date.ToString("dddd");
            ViewBag.Dagens = datum;
            ViewBag.Veckodag = day;
            var week = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.vecka = week;
            var viewModel = new UnitResViewModel();
            
            var resource = _context.Resources.OrderBy(u => u.UnitId).ToList();
            IEnumerable<Resource> resources = resource;
            viewModel.ResourcesList = resources;

            var unit = _context.Units.ToList();
            IEnumerable<Unit> units = unit;
            viewModel.UnitsList = units;

            List<string> weekdays = new List<string> { "må", "ti", "on", "to", "fr", "lö", "sö" };
            //var wday = viewModel.WeekDays;
            ViewBag.WeekDays = weekdays;

            return View(viewModel);
        }

        //("yyyy’-‘MM’-‘dd’");



        // GET: OverViewController
        public ActionResult OverviewResource(int id)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            var date = DateTime.Now;
            var datum = date.ToString("yyyy-MM-dd");
            var day = date.ToString("dddd");
            ViewBag.Dagens = datum;
            ViewBag.Veckodag = day;
            var week = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.vecka = week;
            var viewModel = new UnitResViewModel();

            var resource = _context.Resources.FirstOrDefault(r => r.ResId == id);
            viewModel.Resource = resource;

            var unit = _context.Units.FirstOrDefault(u => u.UnitId == resource.UnitId);
            viewModel.Unit = unit;
            ViewBag.EnhetsAdress = unit.Address;
            List<string> weekdays = new List<string> { "må", "ti", "on", "to", "fr", "lö", "sö" };
            ViewBag.WeekDays = weekdays;

            return View(viewModel);
        }

        // GET: OverViewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OverViewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OverViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OverViewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OverViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OverViewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OverViewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
