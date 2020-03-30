using System.Threading.Tasks;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Epila.Ph.WebApi.Contracts;
using Epila.Ph.WebApi.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Epila.Ph.WebApi.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorManager _monitorManager;

        public MonitorController(IMonitorManager monitorManager)
        {
            _monitorManager = monitorManager;
        }

        [HttpGet]
        public async Task<ApiResponse> Get()
        {
            var data = await _monitorManager.GetAllAsync().ConfigureAwait(false);
            return new ApiResponse(data);
        }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<ApiResponse> Get(long id)
        {
            var data = await _monitorManager.GetByIdAsync(id).ConfigureAwait(false);
            if (data != null)
                return new ApiResponse(data);
            else
                throw new ApiException($"Record with id: {id} does not exist.", Status404NotFound);
        }

        [HttpPost]
        public async Task<ApiResponse> Post([FromBody] MonitorRequest request)
        {
            if (!ModelState.IsValid) throw new ApiException(ModelState.AllErrors());
            var result = await _monitorManager.CreateAsync(request).ConfigureAwait(false);
            return new ApiResponse("Record successfully created.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpPut]
        public async Task<ApiResponse> Put(long id, [FromBody] MonitorRequest request)
        {
            if (!ModelState.IsValid) throw new ApiException(ModelState.AllErrors());
            var result = await _monitorManager.UpdateAsync(request,id).ConfigureAwait(false);
            return new ApiResponse("Record successfully updated.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpDelete]
        public async Task<ApiResponse> Delete(long id)
        {
            if (await _monitorManager.DeleteAsync(id))
                return new ApiResponse($"Record with Id: {id} sucessfully deleted.", true);
            else
                throw new ApiException($"Record with id: {id} does not exist.", Status404NotFound);
        }
    }
}