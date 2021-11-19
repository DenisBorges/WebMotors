using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Services
{
    public interface IWebMotorsService
    {
        Task<List<MakeDto>> GetMake();
        Task<List<ModelDto>> GetModel(int makeId);
        Task<List<VersionDto>> GetVersion(int modelId);
        Task<List<VehiclesDto>> GetVehicles(int page);
    }
}
