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

/*
builder.Services.AddScoped<IAltaAmenaza, AltaAmenaza>();
builder.Services.AddScoped<IBajaAmenaza, BajaAmenaza>();
builder.Services.AddScoped<IBuscarAmenazaPorId, BuscarAmenazaPorId>();
builder.Services.AddScoped<IListarAmenaza, ListarAmenaza>();
builder.Services.AddScoped<IModificarAmenaza, ModificarAmenaza>();

builder.Services.AddScoped<IAltaEcosistema, AltaEcosistema>();
builder.Services.AddScoped<IBajaEcosistema, BajaEcosistema>();
builder.Services.AddScoped<IBuscarEcosistemaPorId, BuscarEcosistemaPorId>();
builder.Services.AddScoped<IListarEcosistemas, ListarEcosistema>();
builder.Services.AddScoped<IModificarEcosistema, ModificarEcosistema>();

builder.Services.AddScoped<IAltaEspecieMarina, AltaEspecie>();
builder.Services.AddScoped<IBajaEspecieMarina, BajaEspecie>();
builder.Services.AddScoped<IBuscarEspeciePorId, BuscarEspeciePorId>();
builder.Services.AddScoped<IListarEspecies, ListarEspecies>();
builder.Services.AddScoped<IModificarEspecie, ModificarEspecie>();

builder.Services.AddScoped<IAltaEstadoConservacion, IAltaEstadoConservacion>();
builder.Services.AddScoped<IBajaEstadoConservacion, BajaEstado>();
builder.Services.AddScoped<IBuscarEstadoConservacionPorId, BuscarEstadoPorId>();
builder.Services.AddScoped<IListarEstadoConservacion, ListarEstados>();
builder.Services.AddScoped<IModificarEstadoConservacion, ModificarEstado>();

builder.Services.AddScoped<IAltaPais, AltaPais>();
builder.Services.AddScoped<IBajaPais, BajaPais>();
builder.Services.AddScoped<IBuscarPaisPorId, BuscarPaisPorId>();
builder.Services.AddScoped<IListarPais, ListarPaises>();
builder.Services.AddScoped<IModificarPais, ModificarPais>();

builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
builder.Services.AddScoped<IBuscarUsuarioPorId, BuscarUsuarioPorId>();
builder.Services.AddScoped<IListarUsuarios, ListarUsuarios>();
builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
*/

// REPOSITORIOS
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();

// CASOS DE USO
// Usuario
builder.Services.AddScoped<ILoginUsuario, CULoginUsuario>();
builder.Services.AddScoped<IRegistroUsuario, CURegistroUsuario>();
// Ecosistema
builder.Services.AddScoped<IRegistroEcosistema, CURegistroEcosistema>();
// Pais
builder.Services.AddScoped<IListarPaises, CUListarPaises>();
// Amenazas
builder.Services.AddScoped<IListarAmenazas, CUListarAmenazas>();

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
