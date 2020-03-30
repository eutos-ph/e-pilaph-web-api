using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epila.Ph.Api.Contracts;
using Epila.Ph.Api.Data.Entity;
using Epila.Ph.Api.DTO.Request;
using Microsoft.Extensions.Configuration;

namespace Epila.Ph.Api.Data.DataManager
{
    public class QueueTypeManager : DbFactoryBase,IQueueTypeManager
    {
        public QueueTypeManager(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<QueueType>> GetAllAsync()
        {
            return await DbQueryAsync<QueueType>("[dbo].[usp_QueueTypeSelect]").ConfigureAwait(false);
        }

        public async Task<QueueType> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_QueueTypeSelect]", new { Id = id }).ConfigureAwait(false);
        }

        public async Task<QueueType> CreateAsync(QueueTypeRequest entity)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_QueueTypeInsert]", entity).ConfigureAwait(false);
        }

        public async Task<QueueType> UpdateAsync(QueueTypeRequest entity, object id)
        {
            return await DbQuerySingleAsync<QueueType>("[dbo].[usp_QueueTypeUpdate]",new
            {
                entity.UserName,
                entity.QueueTypeName,
                entity.QueueTypeDescription,
                Id=id
            }).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await DbExecuteAsync<bool>("[dbo].[usp_QueueTypeDelete]", new { id }).ConfigureAwait(false);
        }

        public async Task<bool> ExistAsync(object id)
        {
            throw  await Task.FromResult( new NotImplementedException()).ConfigureAwait(false);
        }
    }
}
