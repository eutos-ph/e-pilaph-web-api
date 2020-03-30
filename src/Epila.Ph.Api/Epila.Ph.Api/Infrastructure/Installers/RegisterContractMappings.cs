using Epila.Ph.Api.Contracts;
using Epila.Ph.Api.Data.DataManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epila.Ph.Api.Infrastructure.Installers
{
    internal class RegisterContractMappings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Register Interface Mappings for Repositories
            services.AddTransient<IPersonManager, PersonManager>();

            services.AddTransient<IKioskManager, KioskManager>();
            services.AddTransient<IMonitorManager, MonitorManager>();
            services.AddTransient<IQueueTypeManager, QueueTypeManager>();
        }
    }
}
