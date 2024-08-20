using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteMembers.Requests
{
    public class GetInstituteMembersForCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        public long? ActivityId { get; set; }
    }
}