using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Epila.Ph.WebApi.Data
{
    public abstract class DbFactoryBase
    {
        private readonly IConfiguration _config;

        internal string DbConnectionString => _config.GetConnectionString("SQLDBConnectionString");

        public DbFactoryBase(IConfiguration config)
        {
            _config = config;
        }

        internal IDbConnection DbConnection => new SqlConnection(_config.GetConnectionString("SQLDBConnectionString"));

       public virtual async Task<IEnumerable<T>> DbQueryAsync<T>(string sql,object parameters = null,CommandType commandType=CommandType.StoredProcedure)
       {
           using var dbCon = DbConnection;
           if (parameters == null)
               return await dbCon.QueryAsync<T>(sql,commandType).ConfigureAwait(false);

           return await dbCon.QueryAsync<T>(sql, parameters, commandType:commandType);
       }

        public virtual async Task<T> DbQuerySingleAsync<T>(string sql, object parameters, CommandType commandType=CommandType.StoredProcedure)
        {
            using var dbCon = DbConnection;
            return await dbCon.QueryFirstOrDefaultAsync<T>(sql, parameters,commandType:commandType);
        }

        public virtual async Task<bool> DbExecuteAsync<T>(string sql, object parameters, CommandType commandType=CommandType.StoredProcedure)
        {
            using var dbCon = DbConnection;
            return await dbCon.ExecuteAsync(sql, parameters,commandType:commandType) > 0;
        }

        public virtual async Task<bool> DbExecuteScalarAsync(string sql, object parameters)
        {
            using var dbCon = DbConnection;
            return await dbCon.ExecuteScalarAsync<bool>(sql, parameters);
        }

        public virtual async Task<T> DbExecuteScalarDynamicAsync<T>(string sql, object parameters = null)
        {
            using (IDbConnection dbCon = DbConnection)
            {
                if (parameters == null)
                    return await dbCon.ExecuteScalarAsync<T>(sql);

                return await dbCon.ExecuteScalarAsync<T>(sql, parameters);
            }
        }

        public virtual async Task<(IEnumerable<T> Data, int RecordCount)> DbQueryMultipleAsync<T>(string sql, object parameters = null)
        {
            IEnumerable<T> data;
            int totalRecords = 0;

            using (IDbConnection dbCon = DbConnection)
            {
                using (GridReader results = await dbCon.QueryMultipleAsync(sql, parameters))
                {
                    data = await results.ReadAsync<T>();
                    totalRecords = await results.ReadSingleAsync<int>();
                }
            }

            return (data, totalRecords);
        }
    }
}
