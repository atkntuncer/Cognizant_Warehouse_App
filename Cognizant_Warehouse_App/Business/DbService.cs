using Cognizant_Warehouse_App.Model;
using Cognizant_Warehouse_App.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace Cognizant_Warehouse_App.Business
{
    public class DbService : IDbService
    {
        private readonly IBaseRepository _repository;
        private readonly ILogger<DbService> _logger;

        public DbService(IBaseRepository repository, ILogger<DbService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all vehicle
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            List<Vehicle> vehicleList = new();
            var query = "select * from Cars order by Added_Date";
            try
            {
                _logger.LogInformation("Starting to get vehicle list");
                
                vehicleList = await _repository.ReadAsync<Vehicle>(query);

                _logger.LogInformation("Vehicle list has gotten");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error ocurred when getting data: " + ex.Message,ex);
            }

            return vehicleList;
        }

        /// <summary>
        /// Insert vehicle data to shopping cart
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<bool> InsertVehicletoCartAsync(Vehicle vehicle)
        {
            var cart = new ShoppingCart
            {
                Car_Id = vehicle.Id
            };
            var returnValue = false;
            var query = "insert into Shopping_Cart (Car_Id) values (@Car_Id)";
            try
            {
                returnValue = await _repository.CreateAsync<ShoppingCart>(query, cart);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error ocurred when inserting data: " + ex.Message, ex);
            }
            return returnValue;
        }

        /// <summary>
        /// Get vehicle list from shopping cart
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetVehiclesIntheCartAsync()
        {
            var query = "SELECT ca.* from Shopping_Cart as sc left JOIN Cars as ca on sc.Car_Id=ca.Id";
            List<Vehicle> vehicle = new();
            try
            {
                vehicle = await _repository.ReadAsync<Vehicle>(query);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error ocurred when getting data: " + ex.Message, ex);
            }
            return vehicle;
        }

        /// <summary>
        /// Delete vehicle data from shopping cart
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<bool> DeleteVehicleFromCartAsync(Vehicle vehicle)
        {
            var cart = new ShoppingCart
            {
                Car_Id = vehicle.Id
            };
            var returnValue = false;
            var query = "delete from Shopping_Cart where Car_Id==@Car_Id limit 1";
            try
            {
                returnValue = await _repository.DeleteAsync(query, cart);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error ocurred when inserting data: " + ex.Message, ex);
            }
            return returnValue;
        }
    }
}
