using Microsoft.EntityFrameworkCore;
using TrelloClone.DataAccess.Context;
using TrelloClone.DataAccess.EFCore.Extensions;
using TrelloClone.Business.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APILayer.JwtService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TrelloCloneDbContext>(options =>
    options.UseInMemoryDatabase("TrelloCloneDB"));
builder.Services.AddBusinessServices();
builder.Services.AddEFCoreServices(builder.Configuration);
builder.Services.AddScoped<JwtAuthenticationService>(provider =>
        new JwtAuthenticationService("veryverysecretkey2024veryverysecretkey2024veryverysecretkey2024veryverysecretkey2024", "kiziltancihanoral", "TrelloCloneProject"));
builder.Services.AddControllers();
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
