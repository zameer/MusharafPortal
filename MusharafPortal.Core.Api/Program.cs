using FluentAssertions.Common;
using Microsoft.AspNetCore.OData;
using Musharaf.Portal.Core.Api.Brokers.Loggings;
using Musharaf.Portal.Core.Api.Brokers.Storages;
using Musharaf.Portal.Core.Api.Services.Foundations.Tenants;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StorageBroker>();

//Add Brokers
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ITenantService, TenantService>();

builder.Services.AddControllers().AddOData(options => 
    options.Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(null)
        .Count());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
