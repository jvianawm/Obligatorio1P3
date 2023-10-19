using LogicaAccesoDatos;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.ValueObjects;

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
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();
//builder.Services.AddScoped<IRepositorioLog, RepositorioLog>();

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

builder.Services.AddScoped<IModificarMinCharNombreCientifico, CUModificarMinCharNombreCientifico>();
builder.Services.AddScoped<IModificarMaxCharNombreCientifico, CUModificarMaxCharNombreCientifico>();

builder.Services.AddScoped<IModificarMinCharDescripcionEspecie, CUModificarMinCharDescripcionEspecie>();
builder.Services.AddScoped<IModificarMaxCharDescripcionEspecie, CUModificarMaxCharDescripcionEspecie>();

// Estados de conservacion
builder.Services.AddScoped<IListarEstadoConservacion, CUListarEstados>();


ConfigurationBuilder confBuilder = new ConfigurationBuilder();
confBuilder.AddJsonFile("appsettings.json", false, true);
var config = confBuilder.Build();

string strCon = config.GetConnectionString("MiConexion");
builder.Services.AddDbContextPool<PlataformaContext>(options => options.UseSqlServer(strCon));




DbContextOptionsBuilder<PlataformaContext> b = new DbContextOptionsBuilder<PlataformaContext>();
b.UseSqlServer(strCon);
var opciones = b.Options;
PlataformaContext ctx = new PlataformaContext(opciones);
RepositorioParametros repo = new RepositorioParametros(ctx);

NombreCientifico.MinCharNom = int.Parse(repo.BuscarValorPorNombre("MinCharNom"));
NombreCientifico.MaxCharNom = int.Parse(repo.BuscarValorPorNombre("MaxCharNom"));
DescripcionEspecie.MinCharDesc = int.Parse(repo.BuscarValorPorNombre("MinCharDesc"));
DescripcionEspecie.MaxCharDesc = int.Parse(repo.BuscarValorPorNombre("MaxCharDesc"));




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
