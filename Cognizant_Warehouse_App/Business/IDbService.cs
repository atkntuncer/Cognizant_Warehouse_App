using Cognizant_Warehouse_App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Business
{
    public interface IDbService
    {
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<bool> InsertVehicletoCartAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetVehiclesIntheCartAsync();
        Task<bool> DeleteVehicleFromCartAsync(Vehicle vehicle);
    }
}