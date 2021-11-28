using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.UI.Models;

namespace WebMotors.UI
{
    public interface IWebMotorsService
    {
        Task CriarAnuncio(AnuncioWebMotors register);
        Task ExcluirAnuncio(int id);
        Task<List<AnuncioWebMotors>> ListarTodos();
        Task AtualizarAnuncio(AnuncioWebMotors register);
        Task<List<MakeDto>> GetMake();
        Task<List<ModelDto>> GetModel(int makeId);
        Task<List<VersionDto>> GetVersion(int modelId);
        Task<List<VehiclesDto>> GetVehicles(int page);
    }
}
