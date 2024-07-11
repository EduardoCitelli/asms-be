using ASMS.CrossCutting.Services;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Infrastructure;
using ASMS.Persistence;
using ASMS.Persistence.Abstractions;
using ASMS.Services;
using ASMS.Services.Abstractions;

namespace ASMS.API.Extensions
{
    public static class ServicesStartup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ValidateModelAttribute>();

            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPlanService, PlanService>();
            services.AddTransient<IInstituteService, InstituteService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<ICoachService, CoachService>();
            services.AddTransient<IMembershipTypeService, MembershipTypeService>();
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<IStaffMemberService, StaffMemberService>();
            services.AddTransient<IInstituteMemberService, InstituteMemberService>();
            services.AddTransient<IInstitutePlanService, InstitutePlanService>();
            services.AddTransient<IInstituteMemberMembershipService, InstituteMemberMembershipService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IInstituteClassService, InstituteClassService>();
            services.AddTransient<IInstituteClassBlockService, InstituteClassBlockService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstituteIdService, InstituteIdService>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<IClientTimeOffsetService, ClientTimeOffsetService>();

            services.AddSingleton<ITranslateService, TranslateService>();

            services.AddApplicationInsightsTelemetry(configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

            return services;
        }
    }
}