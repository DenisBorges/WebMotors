using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.AppService.Interface;
using WebMotors.AppService.ViewModel;

namespace WebMotors.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnuncioWebMotorsController : ControllerBase
    {
        private readonly IAnuncioWebMotorsAppService _appService;
        private readonly IWebMotorsAppService _service;
        private readonly ILogger<AnuncioWebMotorsController> _log;
        public AnuncioWebMotorsController(IAnuncioWebMotorsAppService appService,
            IWebMotorsAppService service,
        ILogger<AnuncioWebMotorsController> log 
           )
        {
            _appService = appService;
            _log = log;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAnuncio([FromBody] AnuncioWebMotorsViewModel register)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _appService.AddAnuncio(register);

                return Ok();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }

        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirAnuncio([FromQuery] int id)
        {

            try
            {
                await _appService.ApagarAnuncio(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {

            try
            {
                var lista = await _appService.GetAllAnuncios();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarPorFiltro([FromQuery] AnuncioWebMotorsViewModel filtro)
        {

            try
            {
                var lista = await _appService.GetAnunciosByFilter(filtro);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAnuncio([FromBody] AnuncioWebMotorsViewModel register)
        {

            try
            {
                 await _appService.AtualizarAnuncio(register);

                return Ok();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMake()
        {

            try
            {
                var lista = await _service.GetMake();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(int makeId)
        {

            try
            {
                var lista = await _service.GetModel(makeId);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVersion(int modelId)
        {

            try
            {
                var lista = await _service.GetVersion(modelId);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles(int page)
        {

            try
            {
                var lista = await _service.GetVehicles(page);

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro durante a tentativa. Por favor tente novamente");
            }
        }

    }
}
