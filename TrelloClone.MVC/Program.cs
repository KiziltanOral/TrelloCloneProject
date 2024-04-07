using TrelloClone.DataAccess.EFCore.Extensions;
using TrelloClone.Business.Extensions;
using TrelloClone.Business.Interfaces;
using TrelloClone.Business.Services;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.DataAccess.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using TrelloClone.DataAccess.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<TrelloCloneDbContext>(options =>
    options.UseInMemoryDatabase("TrelloCloneDB"));
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddScoped<IListRepository, ListRepository>();
builder.Services.AddScoped<ICardOrdersService, CardOrdersService>();
builder.Services.AddScoped<ICardOrdersRepository, CardOrdersRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
