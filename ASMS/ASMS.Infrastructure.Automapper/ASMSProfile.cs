using ASMS.Infrastructure.Automapper.Configurations;
using AutoMapper;

namespace ASMS.Infrastructure.Automapper
{
    public class ASMSProfile : Profile
    {
        public ASMSProfile()
        {
            this.AddRoleCofig();
        }
    }
}