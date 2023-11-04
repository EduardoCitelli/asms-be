using ASMS.Infrastructure.Automapper.Configurations;
using AutoMapper;

namespace ASMS.Infrastructure.Automapper
{
    public class ASMSProfile : Profile
    {
        public ASMSProfile()
        {
            this.AddRoleConfig();
            this.AddInstituteConfig();
            this.AddUserConfig();
            this.AddAuthConfig();
            this.AddPlanConfig();
            this.AddActivityConfig();
            this.AddRoomConfig();
            this.AddCoachConfig();
            this.AddMembershipTypeConfig();
            this.AddMembershipConfig();
            this.AddStaffMemberConfig();
            this.AddInstituteMemberConfig();
        }
    }
}