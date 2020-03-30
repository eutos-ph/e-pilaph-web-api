using Epila.Ph.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epila.Ph.Api.Data.Entity;
using Epila.Ph.Api.DTO.Request;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Epila.Ph.Api.Data.DataManager
{
    public class MonitorManager : DbFactoryBase, IMonitorManager
    {
        public async Task<IEnumerable<Monitor>> GetAllAsync()
        {
            return await DbQueryAsync<Monitor>("[dbo].[usp_MonitorSelect]").ConfigureAwait(false);
        }

        public async Task<Monitor> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<Monitor>("[dbo].[usp_MonitorSelect]", new { Id = id }).ConfigureAwait(false);
        }

        public async Task<Monitor> CreateAsync(MonitorRequest entity)
        {
            return await DbQuerySingleAsync<Monitor>("[dbo].[usp_MonitorInsert]", entity).ConfigureAwait(false);
        }

        public async Task<Monitor> UpdateAsync(MonitorRequest entity,object id)
        {
            return await DbQuerySingleAsync<Monitor>("[dbo].[usp_MonitorUpdate]",new
            {
                entity.UserName,
                entity.MonitorName,
                Id=id
            }).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await DbExecuteAsync<bool>("[dbo].[usp_MonitorDelete]", new { id }).ConfigureAwait(false);
        }

        public async Task<bool> ExistAsync(object id)
        {
            throw  await Task.FromResult( new NotImplementedException()).ConfigureAwait(false);
        }

        public MonitorManager(IConfiguration config) : base(config)
        {
        }
    }
}
