﻿using System.Threading.Tasks;
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
    public class KioskController : ControllerBase
    {
       private readonly IKioskManager _kioskManager;

        public KioskController(IKioskManager kioskManager)
        {
            _kioskManager = kioskManager;
        }

        [HttpGet]
        public async Task<ApiResponse> Get()
        {
            var data = await _kioskManager.GetAllAsync().ConfigureAwait(false);
            return new ApiResponse(data);
        }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<ApiResponse> Get(long id)
        {
            var data = await _kioskManager.GetByIdAsync(id).ConfigureAwait(false);
            if (data != null)
                return new ApiResponse(data);
            throw new ApiException($"Record with id: {id} does not exist.", Status404NotFound);
        }

        [HttpPost]
        public async Task<ApiResponse> Post([FromBody] KioskRequest request)
        {
            if (!ModelState.IsValid) throw new ApiException(ModelState.AllErrors());
            var result = await _kioskManager.CreateAsync(request).ConfigureAwait(false);
            return new ApiResponse("Record successfully created.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpPut]
        public async Task<ApiResponse> Put(long id, [FromBody] KioskRequest request)
        {
            if (!ModelState.IsValid) throw new ApiException(ModelState.AllErrors());
            var result = await _kioskManager.UpdateAsync(request,id).ConfigureAwait(false);
            return new ApiResponse("Record successfully updated.", result, Status201Created);
        }

        [Route("{id:long}")]
        [HttpDelete]
        public async Task<ApiResponse> Delete(long id)
        {
            if (await _kioskManager.DeleteAsync(id))
                return new ApiResponse($"Record with Id: {id} sucessfully deleted.", true);
            throw new ApiException($"Record with id: {id} does not exist.", Status404NotFound);
        }
    }
}
