using Epila.Ph.WebApi.Contracts;
using Epila.Ph.WebApi.Data.DataManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epila.Ph.WebApi.Infrastructure.Installers
{
    internal class RegisterContractMappings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Register Interface Mappings for Repositories
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IMonitorManager, MonitorManager>();
            services.AddTransient<IKioskManager, KioskManager>();
            services.AddTransient<IQueueTypeManager, QueueTypeManager>();
            services.AddTransient<IKioskQueueTypeManager, KioskQueueTypeManager>();
        }
    }
}
