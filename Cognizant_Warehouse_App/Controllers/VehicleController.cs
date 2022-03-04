using Cognizant_Warehouse_App.Business;
using Cognizant_Warehouse_App.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IDbService _service;

        public VehicleController(IDbService service)
        {
            _service = service;
        }

        /// <summary>
        /// An api route that get list of vehicles
        /// </summary>
        /// <returns></returns>
        [Route("List")]
        [HttpGet]
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await _service.GetVehiclesAsync();
        }
    }
}
