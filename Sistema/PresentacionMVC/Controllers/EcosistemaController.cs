using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using PresentacionMVC.Filters;
using System.Drawing;
using PresetacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class EcosistemaController : Controller
    {
        
        public IRegistroEcosistema CURegistroEcosistema { get; set; }
        public IListarPaises CUListarPaises { get; set; }
        public IListarAmenazas CUListarAmenazas { get; set; }

        public EcosistemaController(
            IRegistroEcosistema CURegistro,
            IListarPaises CUListarPaises
        )
        {
            this.CURegistroEcosistema = CURegistro;
            this.CUListarPaises = CUListarPaises;
        }

        #region 3) Registro de ecosistemas
        /* Se registrará el ecosistema con la información anteriormente mencionada, 
           incluyendo la carga de una imagen al servidor donde esté alojado el MVC, 
           siguiendo las reglas mencionadas anteriormente.
        */

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult Registro()
        {
            IEnumerable<Pais> paises = CUListarPaises.Listar();
            return View();
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult Registro(RegistroEcosistemaViewModel registro)
        {
            try
            {

                IEnumerable<Pais> paises = CUListarPaises.Listar();

                /*
                AutorViewModel vm = new AutorViewModel()
                {
                    Autor = new Autor(),
                    Paises = paises
                };
                */

                /*
                if (registro.Usuario.Password == registro.ClaveConfirmada)
                {
                    CURegistroUsuario.Registrar(registro.Usuario);
                    TempData["MensajeExito"] = "Se creó el usuario " + registro.Usuario.Alias;
                    return RedirectToAction("Registro", "Usuario");
                }
                else
                {
                    ViewBag.MensajeError = "Las contraseñas no coinciden";
                }
                */

            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(registro);
        }

        #endregion

    }
}
