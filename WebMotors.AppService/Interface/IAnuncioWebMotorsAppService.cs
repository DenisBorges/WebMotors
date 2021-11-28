using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.AppService.ViewModel;

namespace WebMotors.AppService.Interface
{
    public interface IAnuncioWebMotorsAppService
    {
        Task AddAnuncio(AnuncioWebMotorsViewModel anuncio);
        Task<List<AnuncioWebMotorsViewModel>> GetAllAnuncios();

        Task ApagarAnuncio(int id);

        Task AtualizarAnuncio(AnuncioWebMotorsViewModel anuncio);

        Task<List<AnuncioWebMotorsViewModel>> GetAnunciosByFilter(AnuncioWebMotorsViewModel filter);
    }
}
