using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epila.Ph.Api.Data.Entity;
using Epila.Ph.Api.DTO.Request;

namespace Epila.Ph.Api.Contracts
{
    public interface IQueueTypeManager: IRepository<QueueType,QueueTypeRequest>
    {
    }
}
