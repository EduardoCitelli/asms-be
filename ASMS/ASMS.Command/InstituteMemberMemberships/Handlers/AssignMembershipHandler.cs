using ASMS.Command.InstituteMemberMemberships.Commands;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.InstituteMemberMemberships.Handlers
{
    public class AssignMembershipHandler : IRequestHandler<AssignMembershipCommand, BaseApiResponse<long>>
    {
        private readonly IInstituteMemberMembershipService _service;
        private readonly IMembershipService _membershipService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public AssignMembershipHandler(IInstituteMemberMembershipService service,
                                       IMembershipService membershipService,
                                       IPaymentService paymentService,
                                       IMapper mapper)
        {
            _service = service;
            _membershipService = membershipService;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<BaseApiResponse<long>> Handle(AssignMembershipCommand request, CancellationToken cancellationToken)
        {
            var membership = await _membershipService.GetEntityByIdAsync(request.MembershipId, x => x.Include(x => x.MembershipType));

            return await _service.CreateAsync(request, x =>
            {
                x.ExpirationDate = x.StartDate.AddMonths(membership.MembershipType.MonthQuantity);
            });
        }
    }
}
