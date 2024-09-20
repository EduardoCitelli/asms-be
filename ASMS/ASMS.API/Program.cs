using ASMS.API.Extensions;
using ASMS.Command.Users.Handlers;
using ASMS.CrossCutting.Utils;
using ASMS.Infrastructure.Automapper;
using ASMS.Queries.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers()
        .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
        });

services.AddContext(builder.Configuration);

services.InitializeCors();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMediatR(typeof(GetAllRolesQueryHandler).Assembly);
services.AddMediatR(typeof(UserCreateHandler).Assembly);
services.AddAutoMapper(typeof(ASMSProfile));
services.AddSwagger();
services.AddJwt(builder.Configuration);

services.ConfigureServices(builder.Configuration);
services.ConfigureMiddlewares();
services.ConfigureScheduler();

var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseCors("CorsPolicy");

app.UseSwaggerApplication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseMiddlewares();

app.UseSchedulers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.CheckAndRunMigrations();

await app.RunAsync();
