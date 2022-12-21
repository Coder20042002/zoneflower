﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using zoneFlower.BackendApi.Models;

namespace zoneFlower.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        
    }
}