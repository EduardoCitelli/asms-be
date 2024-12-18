﻿using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.CrossCutting.Utils.Models;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClassBlocks.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASMS.API.Controllers
{
    public class InstituteClassBlockController : DefaultController
    {
        public InstituteClassBlockController(IMediator mediator, ILogger<InstituteClassBlockController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<BaseApiResponse<PagedList<InstituteClassBlockListDto>>> GetAll([FromQuery] GetAllClassBlocks request)
        {
            request.RootFilter = request.Filter.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject<RootFilter>(request.Filter);
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<BaseApiResponse<InstituteClassBlockSingleDto>> GetById([FromRoute] long id)
        {
            return await _mediator.Send(new GetClassBlockById(id));
        }

        [HttpGet("calendar")]
        public async Task<BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>> GetForCalendar([FromQuery] GetBlocksForCalendar request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}/[action]")]
        public async Task<BaseApiResponse<bool>> Cancel([FromRoute] long id)
        {
            return await _mediator.Send(new CancelBlock(id));
        }

        [HttpPut("{id}/[action]")]
        public async Task<BaseApiResponse<bool>> AddMember([FromRoute] long id)
        {
            return await _mediator.Send(new AddMember(id));
        }

        [HttpPut("{id}/[action]")]
        public async Task<BaseApiResponse<bool>> RemoveMember([FromRoute] long id)
        {
            return await _mediator.Send(new RemoveMember(id));
        }

        [HttpPut("{id}/[action]")]
        public async Task<BaseApiResponse<bool>> UpdateMembers([FromRoute] long id, [FromBody] IList<long> members)
        {
            return await _mediator.Send(new UpdateMembers(id, members));
        }
    }
}