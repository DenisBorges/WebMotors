using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebMotors.UI.Models;

namespace WebMotors.UI.Views.Shared.Components
{
    public class CardMeusAnunciosComponent : ViewComponent
    {

        private readonly IWebMotorsService _service;
        public CardMeusAnunciosComponent(IWebMotorsService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {

            var lst = GetMeusAnuncios();

            return View(lst);
        }

        private List<AnuncioWebMotors> GetMeusAnuncios()
        {
            

            var result = _service.ListarTodos().Result;


            return result;
        }
    }
}
