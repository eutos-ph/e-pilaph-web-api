using Epila.Ph.Api.Data;
using Epila.Ph.Api.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epila.Ph.Api.Contracts
{
    public interface IPersonManager : IRepository<Person>
    {
        Task<(IEnumerable<Person> Persons, Pagination Pagination)> GetPersonsAsync(UrlQueryParameters urlQueryParameters);

        //Add more class specific methods here when neccessary
    }
}
