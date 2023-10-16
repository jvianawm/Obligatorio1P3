using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using PresentacionMVC.Filters;
using System.Drawing;
using PresetacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ILoginUsuario CULoginUsuario { get; set; }
        public IRegistroUsuario CURegistroUsuario { get; set; }

        public UsuarioController(
            ILoginUsuario CULogin,
            IRegistroUsuario CURegistro
        )
        {
            CULoginUsuario = CULogin;
            CURegistroUsuario = CURegistro;
        }

        #region 1) Registro de usuario
        /* Se ingresa un usuario al sistema siguiendo las reglas mencionadas anteriormente. 
           Los usuarios no se pueden repetir, y quedan automáticamente autorizados. 
           El único usuario que puede crear otros usuarios es el usuario Admin. 
           La contraseña se deberá confirmar.         
        */

        [HttpGet]
        [SuperUsuario]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [SuperUsuario]
        public ActionResult Registro(RegistroUsuarioViewModel registro)
        {
            try
            {
                if(registro.Usuario.Password == registro.ClaveConfirmada)
                {
                    CURegistroUsuario.Registrar(registro.Usuario);
                    TempData["MensajeExito"] = "Se creó el usuario " + registro.Usuario.Alias;
                    return RedirectToAction("Registro", "Usuario");
                } 
                else
                {
                    ViewBag.MensajeError = "Las contraseñas no coinciden";
                }

            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(registro);
        }

        #endregion


        #region 2) Ingreso al sistema / Salida del sistema
        /* Se permitirá el ingreso al sistema identificándose con usuario y contraseña. 
           Al ingresar correctamente el usuario será autorizado a ingresar a todas las funcionalidades, 
           a excepción de la creación de nuevos usuarios, que está reservada para el usuario “admin1”.
           El usuario podrá salir del sistema cuando lo desee.         
        */

        [HttpGet]
        [UsuarioNoAutenticado]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [UsuarioNoAutenticado]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                CULoginUsuario.Login(usuario);
                HttpContext.Session.SetString("ALIAS", usuario.Alias);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(usuario);
        }

        [HttpGet]
        [UsuarioAutenticado]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        #endregion











        /*
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
