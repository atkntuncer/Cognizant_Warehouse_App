using Cognizant_Warehouse_App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Business
{
    public interface IDbService
    {
        Task<List<Vehicle>> GetVehiclesAsync();
    }
}