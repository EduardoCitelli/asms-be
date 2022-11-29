using ASMS.Command.MembershipTypes.Commands;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.MembershipTypes.Handlers
{
    public class MembershipTypeCreateHandler : IRequestHandler<MembershipTypeCreateCommand, BaseApiResponse<MembershipTypeSingleDto>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeCreateHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Handle(MembershipTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.CreateAsync(request);
        }
    }
}