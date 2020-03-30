using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epila.Ph.WebApi.Contracts;
using Epila.Ph.WebApi.Data.Entity;
using Epila.Ph.WebApi.DTO.Request;
using Microsoft.Extensions.Configuration;

namespace Epila.Ph.WebApi.Data.DataManager
{
    public class KioskQueueTypeManager : DbFactoryBase,IKioskQueueTypeManager
    {
        public KioskQueueTypeManager(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<KioskQueueType>> GetAllAsync()
        {
            return await DbQueryAsync<KioskQueueType>("[dbo].[usp_MonitorSelect]").ConfigureAwait(false);
        }

        public async Task<KioskQueueType> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<KioskQueueType>("[dbo].[usp_MonitorSelect]", new { Id = id }).ConfigureAwait(false);
        }

        public async Task<KioskQueueType> CreateAsync(KioskQueueTypeRequest entity)
        {
            return await DbQuerySingleAsync<KioskQueueType>("[dbo].[usp_MonitorInsert]", entity).ConfigureAwait(false);
        }

        public async Task<KioskQueueType> UpdateAsync(KioskQueueTypeRequest entity, object id)
        {
            return await DbQuerySingleAsync<KioskQueueType>("[dbo].[usp_MonitorUpdate]",new
            {
                entity.UserName,
                entity.KioskId,
                entity.QueueTypeId,
                entity.ReferenceLink,
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
