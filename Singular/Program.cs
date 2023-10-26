using Microsoft.EntityFrameworkCore;
using Singular.Data;
using Singular.Helper;
using Singular.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoContext>
    (options => options.UseMySql("server=186.202.152.119; initial catalog=singularinc;uid=singularinc;pwd=Singular@19",
                          Microsoft.EntityFrameworkCore.ServerVersion.Parse("libmysql - 5.5.62")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, usuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IEmail, Email>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;

});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();