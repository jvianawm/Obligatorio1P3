using LogicaAccesoDatos;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(3);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// REPOSITORIOS
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();
builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
builder.Services.AddScoped<IRepositorioEstadoConservacion, RepositorioEstadoConservacion>();

// CASOS DE USO
// Usuario
builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();
builder.Services.AddScoped<IRegistroUsuario, CURegistroUsuario>();
// Ecosistema
builder.Services.AddScoped<IListarEcosistemas, CUListarEcosistemas>();
builder.Services.AddScoped<IRegistrarEcosistema, CURegistroEcosistema>();
builder.Services.AddScoped<IBuscarEcosistemaPorId, CUBuscarEcosistemaPorId>();
builder.Services.AddScoped<IEliminarEcosistema, CUEliminarEcosistema>();
builder.Services.AddScoped<IAsignarEspecieEcosistema, CUAsignarEspecieEcosistema>();
builder.Services.AddScoped<IBuscarEcosistemasPorEspecieId, CUBuscarEcosistemasPorEspecieId>();
builder.Services.AddScoped<IEcosistemasEspecieNoPuedeHabitar, CUEcosistemasEspecieNoPuedeHabitar>();
    
// Pais
builder.Services.AddScoped<IListarPaises, CUListarPaises>();
// Amenazas
builder.Services.AddScoped<IListarAmenazas, CUListarAmenazas>();
// Especies
builder.Services.AddScoped<IListarEspecies, CUListarEspecies>();
builder.Services.AddScoped<IRegistroEspecie, CURegistroEspecie>();
builder.Services.AddScoped<IBuscarEspeciePorId, CUBuscarEspeciePorId>();
builder.Services.AddScoped<IListarEspeciesEnPeligro, CUListarEspeciesEnPeligro>();
builder.Services.AddScoped<IBuscarPorRangoPeso, CUBuscarPorRangoPeso>();
// Estados de conservacion
builder.Services.AddScoped<IListarEstadoConservacion, CUListarEstados>();


ConfigurationBuilder confBuilder = new ConfigurationBuilder();
confBuilder.AddJsonFile("appsettings.json", false, true);
var config = confBuilder.Build();

string strCon = config.GetConnectionString("MiConexion");
builder.Services.AddDbContextPool<PlataformaContext>(options => options.UseSqlServer(strCon));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
