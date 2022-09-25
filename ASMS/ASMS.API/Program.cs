using ASMS.API.Extensions;
using ASMS.Persistence;
using ASMS.Persistence.Abstractions;
using ASMS.Services;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddContext(builder.Configuration);
services.AddMediatR(Assembly.GetExecutingAssembly());

services.AddTransient<IRoleService, RoleService>();
services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
