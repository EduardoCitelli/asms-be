using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Command.InstituteClassBlocks.Handlers
{
    public class RemoveMemberHandler : IRequestHandler<RemoveMember, BaseApiResponse<bool>>
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public RemoveMemberHandler(IUserInfoService userInfoService,
                                   IInstituteClassBlockService instituteClassBlockService)
        {
            _userInfoService = userInfoService;
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task<BaseApiResponse<bool>> Handle(RemoveMember request, CancellationToken cancellationToken)
        {
            var user = _userInfoService.Value ?? throw new BadRequestException($"User doesn't exist");

            var entity = await _instituteClassBlockService.TryGetExistentEntityAsync(request.Id, GetIncludeQuery());

            var classMember = entity.InstituteMembers.SingleOrDefault(x => x.Id == user.Id) ??
                              throw new BadRequestException($"The member is not assigned to the current class");

            var member = classMember.InstituteMember;

            if (member.ActiveMembership!.Membership.MembershipType.IsByQuantity)
                member.ActiveMembership!.RemainingClasses++;

            entity.InstituteMembers.Remove(classMember);

            entity.ClassStatus = entity.InstituteMembers.Count < entity.Activity.MemberMinQuantity ? ClassStatus.Pending : ClassStatus.Active;

            var response = await _instituteClassBlockService.UpdateEntityAsync(entity);
            return new BaseApiResponse<bool>(response);
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> GetIncludeQuery()
        {
            return x => x.Include(x => x.Header)
                         .Include(x => x.Room)
                         .Include(x => x.InstituteMembers)
                         .ThenInclude(x => x.InstituteMember)
                         .ThenInclude(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .ThenInclude(x => x.MembershipType);
        }
    }
}