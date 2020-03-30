using System.Threading.Tasks;

namespace Epila.Ph.WebApi.Contracts
{
    public interface IAuthServerConnect
    {
        Task<string> RequestClientCredentialsTokenAsync();
    }
}
