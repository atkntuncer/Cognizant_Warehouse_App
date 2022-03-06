using Cognizant_Warehouse_App.Business;
using Cognizant_Warehouse_App.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IDbService _service;

        public ShoppingCartController(IDbService service)
        {
            _service = service;
        }

        /// <summary>
        /// An api route that get list of vehicles in the shopping cart
        /// </summary>
        /// <returns></returns>
        [Route("List")]
        [HttpGet]
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await _service.GetVehiclesIntheCartAsync();
        }

        /// <summary>
        /// An api route that insert vehicle data into shopping cart
        /// </summary>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public async Task<bool> InsertShoppingCart([FromBody] Vehicle vehicle)
        {
            return await _service.InsertVehicletoCartAsync(vehicle);
        }

        /// <summary>
        /// An api route that delete vehicle data from shopping cart
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        public async Task<bool> DeleteVehicleFromCart([FromBody] Vehicle vehicle)
        {
            return await _service.DeleteVehicleFromCartAsync(vehicle);
        }
    }
}
