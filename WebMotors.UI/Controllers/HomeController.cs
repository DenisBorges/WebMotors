using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.UI.Models;

namespace WebMotors.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebMotorsService _service;

        public HomeController(ILogger<HomeController> logger,IWebMotorsService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListarTodos()
        {
            var lst = await _service.ListarTodos();

            return View(lst);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirAnuncio([FromQuery] int id)
        {
             
            try
            {
                await _service.ExcluirAnuncio(id);

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

            
        }

        [HttpGet]
        public IActionResult Cadastrar([FromQuery] int? id)
        {
            AnuncioWebMotors obj = null;

            LoadDropdowns();

            if (id.HasValue)
            {
                var response  =  _service.ListarTodos().Result;
                obj = response.FirstOrDefault(x => x.ID == id);
            }

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody]AnuncioWebMotors anuncio)
        {
            try
            {
                if (anuncio.ID > 0)
                    await _service.AtualizarAnuncio(anuncio);
                else
                    await _service.CriarAnuncio(anuncio);

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetMake()
        {
            var response = await _service.GetMake();

            return Json(response);
        }

        [HttpGet]
        public async Task<JsonResult> GetModelo(int makeId)
        {
            var response = await _service.GetModel(makeId);

            return Json(response);
        }

        [HttpGet]
        public async Task<JsonResult> GetVersion([FromQuery] int modelId)
        {
            var response = await _service.GetVersion(modelId);

            return Json(response);
        }

        [HttpGet]
        public async Task<JsonResult> GetVehicles([FromQuery] int page)
        {
            var response = await _service.GetVehicles(page);

            return Json(response);
        }

        public void LoadDropdowns()
        {
            var marcas = _service.GetMake().Result;
            var lstMarcas = marcas.Select(x => new SelectListItem(x.Name, x.ID.ToString())).ToList();
            lstMarcas.Insert(0, new SelectListItem("Selecione..", "-1", true));
            ViewBag.Marcas = lstMarcas;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
