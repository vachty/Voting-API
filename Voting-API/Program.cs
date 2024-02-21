using Voting_API.Service.Handlers;
using System.Reflection;
using Voting_API.Extensions;
using Voting_API.Service.Mappers;
using MassTransit;
using Shared.Contracts;
using Voting_API.Service.Consumers;

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

builder.Services.AddMassTransit(bus =>
{
    bus.SetKebabCaseEndpointNameFormatter();
    bus.AddConsumer<ElectionCreatedConsumer>();

    bus.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), cfg =>
        {
            cfg.Username(builder.Configuration["MessageBroker:Username"]);
            cfg.Username(builder.Configuration["MessageBroker:Password"]);
        });

        configurator.ConfigureEndpoints(context);
    });
});

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
