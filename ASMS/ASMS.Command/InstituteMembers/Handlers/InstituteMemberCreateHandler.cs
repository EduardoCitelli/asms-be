﻿using ASMS.Command.InstituteMembers.Commands;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Security;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.InstituteMembers.Handlers
{
    public class InstituteMemberCreateHandler : IRequestHandler<InstituteMemberCreateCommand, BaseApiResponse<InstituteMemberSingleDto>>
    {
        private readonly IInstituteMemberService _instituteMemberService;
        private readonly IUserService _userService;

        public InstituteMemberCreateHandler(IInstituteMemberService instituteMemberService, IUserService userService)
        {
            _instituteMemberService = instituteMemberService;
            _userService = userService;
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Handle(InstituteMemberCreateCommand request, CancellationToken cancellationToken)
        {
            await _userService.ValidateExistentInfo(request.User.UserName, request.User.Email);

            request.User.Password = request.User.Password.ToHash();
            request.User.Email = request.User.Email.ToLower();

            return await _instituteMemberService.CreateAsync(request);
        }
    }
}