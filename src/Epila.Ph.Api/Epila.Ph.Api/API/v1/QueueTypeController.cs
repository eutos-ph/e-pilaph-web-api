using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Epila.Ph.Api.Contracts;
using Epila.Ph.Api.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Http.StatusCodes;
namespace Epila.Ph.Api.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QueueTypeController : ControllerBase
    {
        readonly IQueueTypeManager _queueTypeManager;
        private readonly ILogger<QueueTypeController> _logger;

        public QueueTypeController(IQueueTypeManager queueTypeManager, ILogger<QueueTypeController> logger)
        {
            _queueTypeManager = queueTypeManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ApiResponse> Get()
        {
            var data = await _queueTypeManager.GetAllAsync().ConfigureAwait(false);
            return new ApiResponse(data);
        }

        [Route("{id:long}")]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        public async Task<ApiResponse> Get(long id)
        {
            var data = await _queueTypeManager.GetByIdAsync(id).ConfigureAwait(false);
            if (data != null)
                return new ApiResponse(data);
            throw new ApiProblemDetailsException($"Record with id: {id} does not exist.", Status404NotFound);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Post([FromBody] QueueTypeRequest request)
        {
            if (!ModelState.IsValid) throw new ApiProblemDetailsException(ModelState);
            var result = await _queueTypeManager.CreateAsync(request).ConfigureAwait(false);
            return new ApiResponse("Record successfully created.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Put(long id, [FromBody] QueueTypeRequest request)
        {
            if (!ModelState.IsValid) throw new ApiProblemDetailsException(ModelState);
            var result = await _queueTypeManager.UpdateAsync(request, id).ConfigureAwait(false);
            return new ApiResponse("Record successfully updated.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        public async Task<ApiResponse> Delete(long id)
        {
            if (await _queueTypeManager.DeleteAsync(id))
                return new ApiResponse($"Record with Id: {id} successfully deleted.", true);
            throw new ApiException($"Record with id: {id} does not exist.", Status404NotFound);
        }
    }
}