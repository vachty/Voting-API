using Electing_API.Extensions;
using System.Reflection;
using Service.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * Dependency injection
 */
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseHandler<,>).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Service.Mappers.DomainToDtoMappingProfile)));
builder.Services.RegisterServices();

//add the database
builder.Services.AddVotingApiDbContext(builder.Configuration);

builder.Services.SetUpRoutes();
builder.Services.AddSwagger();

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
