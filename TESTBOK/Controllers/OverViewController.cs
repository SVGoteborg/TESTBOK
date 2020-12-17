﻿using System;
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
        [HttpGet]
        public ActionResult Overview(int? id)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            var date = DateTime.Now;
            var datum = date.ToString("yyyy-MM-dd");
            var day = date.ToString("dddd");
            ViewBag.Dagens = datum;
            ViewBag.Veckodag = day;
            ViewBag.yearWeeks = Dates.LastWeekOfYear(date);
            var week = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.vecka = week;
            var viewModel = new UnitResViewModel();
            
            var resource = _context.Resources.OrderBy(u => u.UnitId).ToList();
            IEnumerable<Resource> resources = resource;
            viewModel.ResourcesList = resources;

            var unit = _context.Units.ToList();
            IEnumerable<Unit> filteredUnits = null;
            IEnumerable<Unit> units = unit;
            if (id != null && id != 0)
            {
                filteredUnits = unit.Where(u => u.UnitId == id);
            }
            else
            {
                filteredUnits = unit;
            }
            //IEnumerable<Unit> units = unit;
            viewModel.FilteredUnitsList = filteredUnits;
            viewModel.UnitsList = units;

            IEnumerable<Resource> filteredResources = null;
            if (id != null && id != 0)
            {
                filteredResources = resource.Where(r => r.UnitId == id);
            }
            else
            {
                filteredResources = resources;
            }
            viewModel.FilteredResourceList = filteredResources;

            List<string> weekdays = new List<string> { "må", "ti", "on", "to", "fr", "lö", "sö" };
            ViewBag.WeekDays = weekdays;

            var bookings = _context.Bookings.ToList();
            viewModel.BookingList = bookings;

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
            //var year = cal.GetYear(date);
            
            //DateTime lastDate = new DateTime(year, 12, 31);
            //var lastWeek = cal.GetWeekOfYear(lastDate, dfi.CalendarWeekRule,
            //                                    dfi.FirstDayOfWeek);
            //List<int> weeksOfYear = new List<int>();
            //for (int i = 1; i <= lastWeek; i++)
            //{
            //    weeksOfYear.Add(cal.GetWeekOfYear(date.AddDays(i * 7), dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            //}
            //ViewBag.yearWeeks = weeksOfYear; 
            ViewBag.yearWeeks = Dates.LastWeekOfYear(date);
            ViewBag.Dagens = datum;
            ViewBag.Veckodag = day;
            var week = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            //List<int> weeks = new List<int>();
            //for(int i=0; i < 30; i++)
            //{
            //    weeks.Add(cal.GetWeekOfYear(date.AddDays(i * 7), dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            //}
            DateTime date30w = date.AddDays(30 * 7);
            var week30 = cal.GetWeekOfYear(date30w, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.vecka = week;
            ViewBag.vecka30 = week30;
            //ViewBag.veckor30 = weeks;
            ViewBag.veckor30 = Dates.Get30Weeks(date);
            var viewModel = new UnitResViewModel();

            var resource = _context.Resources.FirstOrDefault(r => r.ResId == id);
            viewModel.Resource = resource;

            var unit = _context.Units.FirstOrDefault(u => u.UnitId == resource.UnitId);
            viewModel.Unit = unit;
            ViewBag.EnhetsAdress = unit.Address;
            List<string> weekdays = new List<string> { "må", "ti", "on", "to", "fr", "lö", "sö" };
            ViewBag.WeekDays = weekdays;

            var bookings = _context.Bookings.ToList();
            viewModel.BookingList = bookings;

            return View(viewModel);
        }

        // GET: OverViewController
        public ActionResult OverviewDay(int id)
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

            var bookings = _context.Bookings.ToList();
            viewModel.BookingList = bookings;

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
