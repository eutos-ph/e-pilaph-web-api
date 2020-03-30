using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epila.Ph.Api.Contracts;
using Epila.Ph.Api.Data.Entity;
using Epila.Ph.Api.DTO.Request;
using Microsoft.Extensions.Configuration;

namespace Epila.Ph.Api.Data.DataManager
{
    public class KioskManager:DbFactoryBase,IKioskManager
    {
        public KioskManager(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<Kiosk>> GetAllAsync()
        {
            return await DbQueryAsync<Kiosk>("[dbo].[usp_KioskSelect]").ConfigureAwait(false);
        }

        public async Task<Kiosk> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<Kiosk>("[dbo].[usp_KioskSelect]", new { Id = id }).ConfigureAwait(false);
        }

        public async Task<Kiosk> CreateAsync(KioskRequest entity)
        {
            return await DbQuerySingleAsync<Kiosk>("[dbo].[usp_KioskInsert]", entity).ConfigureAwait(false);
        }

        public async Task<Kiosk> UpdateAsync(KioskRequest entity, object id)
        {
            return await DbQuerySingleAsync<Kiosk>("[dbo].[usp_KioskUpdate]",new
            {
                entity.UserName,
                entity.KioskName,
                entity.KioskDescription,
                Id=id
            }).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await DbExecuteAsync<bool>("[dbo].[usp_KioskDelete]", new { Id=id }).ConfigureAwait(false);
        }

        public async Task<bool> ExistAsync(object id)
        {
            throw  await Task.FromResult( new NotImplementedException()).ConfigureAwait(false);
        }
    }
}
