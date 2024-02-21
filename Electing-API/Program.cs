using Electing_API.Extensions;
using System.Reflection;
using Electing_API.Service.Handlers;
using Electing_API.Service.Mappers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * Dependency injection
 */
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseHandler<,>).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DtoToDomainMappingProfile)));
builder.Services.RegisterServices();

//add the database
builder.Services.AddVotingApiDbContext(builder.Configuration);

builder.Services.SetUpRoutes();
builder.Services.AddSwagger();

builder.Services.AddMassTransit(bus =>
{
    bus.SetKebabCaseEndpointNameFormatter();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//apply and use migrations to the database
app.UseMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
