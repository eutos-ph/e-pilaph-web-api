using Epila.Ph.WebApi.Data;
using Epila.Ph.WebApi.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epila.Ph.WebApi.Contracts
{
    public interface IPersonManager : IRepository<Person,Person>
    {
        Task<(IEnumerable<Person> Persons, Pagination Pagination)> GetPersonsAsync(UrlQueryParameters urlQueryParameters);

        //Add more class specific methods here when neccessary
    }
}
