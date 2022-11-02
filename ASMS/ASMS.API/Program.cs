using ASMS.API.Extensions;
using ASMS.Command.Users.Handlers;
using ASMS.Infrastructure.Automapper;
using ASMS.Queries.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
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

services.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseCors("CorsPolicy");

app.UseSwaggerApplication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.ConfigMiddlewares();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.CheckAndRunMigrations();

await app.RunAsync();
