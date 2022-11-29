using ASMS.Command.MembershipTypes.Commands;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.MembershipTypes.Handlers
{
    public class MembershipTypeUpdateHandler : IRequestHandler<MembershipTypeUpdateCommand, BaseApiResponse<MembershipTypeSingleDto>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeUpdateHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Handle(MembershipTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.UpdateAsync(request);
        }
    }
}