using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClassBlocks.Commands
{
    public class CancelBlock : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public CancelBlock(long id) : base(id)
        {
        }

        public CancelBlock(long id, bool isDailyCancel) : base(id)
        {
            IsDailyCancel = isDailyCancel;
        }

        public bool IsDailyCancel { get; private set; } = false;
    }
}