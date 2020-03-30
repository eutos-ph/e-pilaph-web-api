using Epila.Ph.WebApi.Contracts;
using Epila.Ph.WebApi.DTO.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epila.Ph.WebApi.Infrastructure.Installers
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

            //Disable Automatic Model State Validation built-in to ASP.NET Core
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }
    }
}
