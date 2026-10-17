using StoreApi.Api.Extensions;
using StoreApi.Api.Filters;
using StoreApi.Application;
using StoreApi.Infrastructure;
using StoreApi.Infrastructure.Migrations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessaging(builder.Configuration);
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
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

await DataBaseMigration.MigrateDataBase(app.Services);

app.Run();
