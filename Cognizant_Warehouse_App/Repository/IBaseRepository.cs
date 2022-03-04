using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Repository
{
    public interface IBaseRepository
    {
        Task<bool> CreateAsync<T>(string sqlQuery, T dto);
        Task<bool> DeleteAsync(string sqlQuery, int id);
        Task<List<T>> ReadAsync<T>(string sqlQuery);
        Task<bool> UpdateAsync<T>(string sqlQuery, T dto);
    }
}