﻿using ASMS.CrossCutting.Services;
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
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ValidateModelAttribute>();

            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstituteService, InstituteService>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            return services;
        }
    }
}