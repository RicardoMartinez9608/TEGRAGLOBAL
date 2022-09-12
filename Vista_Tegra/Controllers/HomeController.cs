using API_TEGRA.Modelo;
using AyCWeb.Controllers;
using AyCWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vista_Tegra.Models;

namespace Vista_Tegra.Controllers
{
    public class HomeController :  BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            string recuroyparametro = string.Format("Product/Products");
            ResponseApi responseApi = await OperarApi(HttpMethod.Get, recuroyparametro, null);
            string contenido = responseApi.ContenidofromJson;
            List<Product> integrantes = JsonConvert.DeserializeObject<List<Product>>(contenido);
            return Ok(integrantes);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
