using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epila.Ph.WebApi.Contracts;
using Epila.Ph.WebApi.Data.Entity;
using Epila.Ph.WebApi.DTO.Request;
using Microsoft.Extensions.Configuration;

namespace Epila.Ph.WebApi.Data.DataManager
{
    public class QueueTypeManager : DbFactoryBase,IQueueTypeManager
    {
        public QueueTypeManager(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<QueueType>> GetAllAsync()
        {
            return await DbQueryAsync<QueueType>("[dbo].[usp_MonitorSelect]").ConfigureAwait(false);
        }

        public async Task<QueueType> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_MonitorSelect]", new { Id = id }).ConfigureAwait(false);
        }

        public async Task<QueueType> CreateAsync(QueueTypeRequest entity)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_MonitorInsert]", entity).ConfigureAwait(false);
        }

        public async Task<QueueType> UpdateAsync(QueueTypeRequest entity, object id)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_MonitorUpdate]",new
            {
                entity.UserName,
                entity.QueueTypeName,
                entity.QueueTypeDescription,
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
    }
}
