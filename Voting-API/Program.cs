using Voting_API.Service.Handlers;
using System.Reflection;
using Voting_API.Extensions;
using Voting_API.Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/*
 * Dependency injection
 */
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseHandler<,>).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DomainToDtoMappingProfile)));
builder.Services.RegisterServices();

//add the database
builder.Services.AddVotingApiDbContext(builder.Configuration);

builder.Services.SetUpRoutes();
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SetSwaggerUI();
}

//apply and use migrations to the database
app.UseMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
