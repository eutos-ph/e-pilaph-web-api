using Epila.Ph.Api.Contracts;
using Epila.Ph.Api.DTO.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epila.Ph.Api.Infrastructure.Installers
{
    internal class RegisterModelValidators : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register DTO Validators
            services.AddTransient<IValidator<CreatePersonRequest>, CreatePersonRequestValidator>();
            services.AddTransient<IValidator<UpdatePersonRequest>, UpdatePersonRequestValidator>();

            //kiosk
            services.AddTransient<IValidator<KioskRequest>,KioskRequestValidator>();
            services.AddTransient<IValidator<MonitorRequest>,MonitorRequestValidator>();
            services.AddTransient<IValidator<QueueTypeRequest>,QueueTypeRequestValidator>();

            //Disable Automatic Model State Validation built-in to ASP.NET Core
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }
    }
}
