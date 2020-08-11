﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }

        public IActionResult SummaryChart()
        {
            return View();
        }

        public JsonResult JsonData()
        {
            var data = SummaryData.TimeSeries();
            return Json(data);
        }

    }
}
