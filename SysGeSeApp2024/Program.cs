using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Repositorys;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAcessoRepository, AcessoRepository>();

builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IFuncaoRepository, FuncaoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<IServidorRepository, ServidorRepository>();
builder.Services.AddScoped<ITabelaRepository, TabelaRepository>();



builder.Services.AddDbContext<SysGeseDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("SysGeseApp"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});




// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
