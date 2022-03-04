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
            try
            {
                _logger.LogInformation("Starting to get vehicle list");

                var query = "select * from Cars order by Added_Date";
                vehicleList = await _repository.ReadAsync<Vehicle>(query);

                _logger.LogInformation("Vehicle list has gotten");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error ocurred when getting data: " + ex.Message,ex);
            }

            return vehicleList;
        }
    }
}
