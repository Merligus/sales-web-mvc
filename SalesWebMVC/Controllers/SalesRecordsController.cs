using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            if (!minDate.HasValue)
                minDate = result.LastOrDefault().Date;
            if (!maxDate.HasValue)
                maxDate = result.FirstOrDefault().Date;
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
