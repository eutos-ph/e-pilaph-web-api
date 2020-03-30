using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epila.Ph.Api.Contracts
{
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
