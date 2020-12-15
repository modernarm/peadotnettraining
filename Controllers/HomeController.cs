using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PEADotNetTraining.Models;
using PEADotNetTraining.Services;
using PEADotNetTraining.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThaiDateService _thaiDateService;
        public HomeController(ILogger<HomeController> logger, IThaiDateService thaiDateService)
        {
            _logger = logger;
            _thaiDateService = thaiDateService;
        }

        public IActionResult Index()
        {
            string thaiDate = _thaiDateService.ShowThaiDate();
            ViewBag.thaiDate = thaiDate;
            return View();
        }

        public IActionResult Privacy()
        {
            CustomerViewModel viewModel = new CustomerViewModel()
            {
                fullName = "customer name",
                postCode = 57000
            };

            ViewData["Customer"] = new CustomerViewModel()
            {
                fullName = "customer viewdata",
                postCode = 57000
            };
            return View(viewModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

