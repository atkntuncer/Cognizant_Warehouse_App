using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cognizant_Warehouse_App.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly string ConnectionString = $@"Data Source={Path.GetDirectoryName(Directory.GetCurrentDirectory())}\Cognizant_Warehouse_App\Warehouses.db;Version=3";
        private readonly ILogger<BaseRepository> _logger;

        public BaseRepository(ILogger<BaseRepository> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// A generic method that pull list of records out from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public async Task<List<T>> ReadAsync<T>(string sqlQuery)
        {
            IEnumerable<T> result = null;
            try
            {
                using (IDbConnection con = new SQLiteConnection(ConnectionString))
                {
                    result = await con.QueryAsync<T>(sqlQuery);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result.ToList();
        }

        /// <summary>
        ///  A generic method that insert record to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync<T>(string sqlQuery, T dto)
        {
            int result = -1;
            try
            {
                using (IDbConnection con = new SQLiteConnection(ConnectionString))
                {
                    result = await con.ExecuteAsync(sqlQuery, dto);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result > 0;
        }

        /// <summary>
        /// A generic method that update record to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(string sqlQuery, T dto)
        {
            int result = -1;
            try
            {
                using (IDbConnection con = new SQLiteConnection(ConnectionString))
                {
                    result = await con.ExecuteAsync(sqlQuery, dto);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result > 0;
        }

        /// <summary>
        /// A generic method that delete record to database
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<T>(string sqlQuery, T dto)
        {
            int result = -1;
            try
            {
                using (IDbConnection con = new SQLiteConnection(ConnectionString))
                {
                    result = await con.ExecuteAsync(sqlQuery, dto);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result > 0;
        }
    }
}
