using ASMS.Command.MembershipTypes.Commands;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.MembershipTypes.Handlers
{
    public class MembershipTypeDeleteHandler : IRequestHandler<MembershipTypeDeleteCommand, BaseApiResponse<MembershipTypeSingleDto>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeDeleteHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Handle(MembershipTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.DeleteAsync(request.Id);
        }
    }
}