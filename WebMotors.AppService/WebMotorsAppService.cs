using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.AppService.Interface;
using WebMotors.Services;

namespace WebMotors.AppService
{
    public class WebMotorsAppService : IWebMotorsAppService
    {

        private readonly IWebMotorsService _service;
        public WebMotorsAppService(IWebMotorsService service)
        {
            _service = service;
        }

        public async Task<List<MakeDto>> GetMake()
        {
            return await _service.GetMake();
        }

        public async Task<List<ModelDto>> GetModel(int makeId)
        {
            return await _service.GetModel(makeId);
        }

        public async Task<List<VehiclesDto>> GetVehicles(int page)
        {
            return await _service.GetVehicles(page);
        }

        public async Task<List<VersionDto>> GetVersion(int modelId)
        {
            return await _service.GetVersion(modelId);
        }
    }
}
