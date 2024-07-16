using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClasses.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Queries.InstituteClasses.Handlers
{
    public class GetInstituteClassByIdHandler : IRequestHandler<GetInstituteClassById, BaseApiResponse<InstituteClassSingleDto>>
    {
        private readonly IInstituteClassService _service;

        public GetInstituteClassByIdHandler(IInstituteClassService service)
        {
            _service = service;
        }

        public async Task<BaseApiResponse<InstituteClassSingleDto>> Handle(GetInstituteClassById request, CancellationToken cancellationToken)
        {
            return await _service.GetOneAsync(request.Id, x => x.Include(x => x.DaysOfWeek));
        }
    }
}
