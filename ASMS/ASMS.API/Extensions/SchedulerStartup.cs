using ASMS.Services.Schedules;
using Coravel;

namespace ASMS.API.Extensions
{
    public static class SchedulerStartup
    {
        public static IServiceCollection ConfigureScheduler(this IServiceCollection services)
        {
            services.AddScheduler();
            return services;
        }

        public static IHost UseSchedulers(this IHost app)
        {
            app.Services.UseScheduler(scheduler =>
            {
                scheduler.Schedule<UpdateClassesStatusDaily>()
                .DailyAt(00, 00);
            });

            return app;
        }
    }
}