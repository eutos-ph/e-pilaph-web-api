using Epila.Ph.WebApi.Data.Entity;
using Epila.Ph.WebApi.DTO.Request;

namespace Epila.Ph.WebApi.Contracts
{
    public interface IKioskManager : IRepository<Kiosk,KioskRequest>
    {
    }
}
