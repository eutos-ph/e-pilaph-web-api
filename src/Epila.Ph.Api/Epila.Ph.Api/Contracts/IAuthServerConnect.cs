using System.Threading.Tasks;

namespace Epila.Ph.Api.Contracts
{
    public interface IAuthServerConnect
    {
        Task<string> RequestClientCredentialsTokenAsync();
    }
}
