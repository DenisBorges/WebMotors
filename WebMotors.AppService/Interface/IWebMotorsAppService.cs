using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Services;

namespace WebMotors.AppService.Interface
{
    public interface IWebMotorsAppService
    {
        Task<List<MakeDto>> GetMake();
        Task<List<ModelDto>> GetModel(int makeId);
        Task<List<VersionDto>> GetVersion(int modelId);
        Task<List<VehiclesDto>> GetVehicles(int page);
    }
}
