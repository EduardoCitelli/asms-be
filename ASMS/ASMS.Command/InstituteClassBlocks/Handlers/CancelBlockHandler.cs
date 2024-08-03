using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.InstituteClassBlocks.Handlers
{
    public class CancelBlockHandler : IRequestHandler<CancelBlock, BaseApiResponse<bool>>
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public CancelBlockHandler(IInstituteClassBlockService instituteClassBlockService)
        {
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task<BaseApiResponse<bool>> Handle(CancelBlock request, CancellationToken cancellationToken)
        {
            var entity = await _instituteClassBlockService.TryGetExistentEntityAsync(request.Id, x => x.Include(x => x.InstituteMembers)
                                                                                                       .ThenInclude(y => y.InstituteMember)
                                                                                                       .ThenInclude(y => y.Memberships)
                                                                                                       .ThenInclude(y => y.Membership)
                                                                                                       .ThenInclude(y => y.MembershipType));

            if (entity.FinishDateTime < DateTime.UtcNow)
                throw new BadRequestException("You can not cancel an older class");

            var membersToRemove = entity.InstituteMembers.Select(x => x.InstituteMember);

            foreach (var memberToRemove in membersToRemove)
            {
                var membership = memberToRemove.Memberships.Where(x => x.IsActiveMembership).First();

                if (membership.Membership.MembershipType.IsByQuantity)
                    membership.RemainingClasses++;
            }

            entity.ClassStatus = ClassStatus.Cancelled;
            entity.InstituteMembers.Clear();

            var result = await _instituteClassBlockService.UpdateEntityAsync(entity);


            return new BaseApiResponse<bool>(result);
        }
    }
}
