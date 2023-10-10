using Microsoft.AspNetCore.Mvc;
using PresentacionMVC.Models;
using System.Diagnostics;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;

namespace PresentacionMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IAltaAmenaza CUAltaAmenaza { get; set; }
        public IBajaAmenaza CUBajaAmenaza { get; set; }
        public IBuscarAmenazaPorId CUBuscarAmenazaPorId { get; set; }
        public IListarAmenaza CUListarAmenaza { get; set; }
        public IModificarAmenaza CUModificarAmenaza { get; set; }


        public HomeController(ILogger<HomeController> logger,
                                                       IAltaAmenaza cuAltaAmenaza, IBajaAmenaza cuBajaAmenaza,
                                                       IBuscarAmenazaPorId cuBuscarAmenazaPorId, IListarAmenaza cuListarAmenaza,
                                                       IModificarAmenaza cuModificarAmenaza)
        {
            _logger = logger;
            CUAltaAmenaza = cuAltaAmenaza;
            CUBajaAmenaza = cuBajaAmenaza;
            CUBuscarAmenazaPorId = cuBuscarAmenazaPorId;
            CUListarAmenaza = cuListarAmenaza;
            CUModificarAmenaza = cuModificarAmenaza;


        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}