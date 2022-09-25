using ASMS.API.Extensions;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Automapper;
using ASMS.Queries.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
services.AddAutoMapper(typeof(ASMSProfile));
services.AddSwagger();

services.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseCors("CorsPolicy");

app.UseSwaggerApplication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ExceptionsMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
