using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using PresentacionMVC.Filters;
using PresentacionMVC.Models;
using LogicaAccesoDatos;
using ExcepcionesPropias;

namespace PresentacionMVC.Controllers
{
    public class EcosistemaController : Controller
    {
        #region Propiedades

        public IRegistrarEcosistema      CURegistroEcosistema { get; set; }
        public IListarPaises             CUListarPaises { get; set; }
        public IListarAmenazas           CUListarAmenazas { get; set; }
        public IListarEspecies           CUListarEspecies { get; set; }
        public IListarEstadoConservacion CUListarEstados { get; set; }
        public IListarEcosistemas        CUListarEcosistemas { get; set; }
        public IBuscarEcosistemaPorId    CUBuscarEcosistemaPorId { get; set; }
        public IEliminarEcosistema       CUEliminarEcosistema { get; set; }
        public IAsignarEspecieEcosistema CUAsignarEspecieEcosistema { get; set; }
        public IWebHostEnvironment       WebHostEnvironment { get; set; }

        #endregion

        #region Constructor

        public EcosistemaController(
            IRegistrarEcosistema      cuRegistro,
            IListarPaises             cuListarPaises,
            IListarAmenazas           cuListarAmenazas,
            IListarEspecies           cuListarEspecies,
            IListarEstadoConservacion cuListarEstados,
            IListarEcosistemas        cuListarEcosistemas,
            IBuscarEcosistemaPorId    cuBuscarEcosistemaPorId,
            IEliminarEcosistema       cuEliminarEcosistema,
            IAsignarEspecieEcosistema cuAsignarEspecieEcosistema,
            IWebHostEnvironment       webHostEnvironment
        )
        {
            CURegistroEcosistema    = cuRegistro;
            CUListarPaises          = cuListarPaises;
            CUListarAmenazas        = cuListarAmenazas;
            CUListarEspecies        = cuListarEspecies;
            CUListarEstados         = cuListarEstados;
            CUListarEcosistemas     = cuListarEcosistemas;
            CUBuscarEcosistemaPorId = cuBuscarEcosistemaPorId;
            CUEliminarEcosistema    = cuEliminarEcosistema;
            CUAsignarEspecieEcosistema = cuAsignarEspecieEcosistema;
            WebHostEnvironment      = webHostEnvironment;
        }

        #endregion

        #region 3) Registro de ecosistemas

        /* Se registrará el ecosistema con la información anteriormente mencionada, 
           incluyendo la carga de una imagen al servidor donde esté alojado el MVC, 
           siguiendo las reglas mencionadas anteriormente.
        */

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult Registro()
        {
            RegistroEcosistemaViewModel vm = new()
            {
                Paises   = CUListarPaises.Listar(),
                Amenazas = CUListarAmenazas.Listar(),
                Especies = CUListarEspecies.Listar(),
                Estados  = CUListarEstados.Listar()
            };

            return View(vm);
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult Registro(RegistroEcosistemaViewModel vm)
        {            
            try
            {
                vm.Ecosistema.Paises   = CUListarPaises.FindByIds(vm.IdsPaisesSeleccionados.ToList()).ToList();
                vm.Ecosistema.Amenazas = CUListarAmenazas.FindByIds(vm.IdsAmenazasSeleccionadas.ToList()).ToList();                
                vm.Ecosistema.EstadoConservacion   = CUListarEstados.ObtenerPorId(vm.IdEstado);

                // Seleccionar especies es opcional
                if(vm.IdsEspeciesSeleccionadas != null 
                && vm.IdsEspeciesSeleccionadas.Count() > 0)
                {
                    vm.Ecosistema.Especies = CUListarEspecies.FindByIds(vm.IdsEspeciesSeleccionadas.ToList()).ToList();
                }

                if (vm.ArchivoImagen == null)
                {
                    throw new EcosistemaException("No se agregó una imagen");
                }

                if (vm.IdEstado == 0)
                {
                    throw new EcosistemaException("Se debe indicar el estado");
                }

                FileInfo imagen = new FileInfo(vm.ArchivoImagen.FileName);
                string extension = imagen.Extension;
                
                if(extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                {
                    throw new Exception("El tipo de imagen debe ser png o jpg");
                }

                string nombreArchivo = "_001" + extension;
                vm.Ecosistema.ArchivoImagen = nombreArchivo;

                CURegistroEcosistema.Registrar(vm.Ecosistema);

                if (vm.ArchivoImagen != null && vm.ArchivoImagen.Length > 0)
                {
                    nombreArchivo = vm.Ecosistema.Id + nombreArchivo;
                    string directorio = WebHostEnvironment.WebRootPath;
                    string rutaCompleta = Path.Combine(directorio, "img" , "ecosistemas", nombreArchivo);

                    FileStream fileStream = new FileStream(rutaCompleta, FileMode.Create);
                    vm.ArchivoImagen.CopyTo(fileStream);
                }

                TempData["MensajeExito"] = "Se creó el ecosistema " + vm.Ecosistema.Nombre;
                return RedirectToAction("Registro", "Ecosistema");
            }
            catch (Exception ex)
            {
                vm.Paises   = CUListarPaises.Listar();
                vm.Amenazas = CUListarAmenazas.Listar();
                vm.Especies = CUListarEspecies.Listar();
                vm.Estados  = CUListarEstados.Listar();

                ViewBag.MensajeError = ex.Message;
                return View(vm);
            }
        }

        #endregion

        #region 4) Listado de ecosistemas

        /* Listar todos los ecosistemas.Se mostrarán todos sus datos, incluyendo la imagen. */

        [HttpGet]
        public ActionResult Listar()
        {
            ListarEcosistemasViewModel vm = new();

            vm.Ecosistemas = CUListarEcosistemas.Listar();

            vm.RutaDirectorioImagenes = Path.Combine("img", "ecosistemas");

            return View(vm);
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            var vm = new DetalleEcosistemaViewModel()
            {
                Ecosistema = CUBuscarEcosistemaPorId.Buscar(id),
                RutaDirectorioImagenesEcosistemas = Path.Combine("img", "ecosistemas")
            };
            
            return View(vm);
        }

        #endregion

        #region 7) Eliminar un ecosistema.

        /* Se podrá eliminar un ecosistema siempre que no tenga especies que efectivamente lo habiten.
           Se debe solicitar confirmación antes de eliminarlo.
        */

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult Delete(int id) 
        {
            Ecosistema ecositema = CUBuscarEcosistemaPorId.Buscar(id);
   
            if (ecositema == null)
            {
                ViewBag.MensajeError = "No se encontró el ecosistema a eliminar";
            }

            return View(ecositema);         
        }

        [HttpPost]
        [UsuarioAutenticado]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ecosistema ecosistema) 
        {        
            try
            {
                CUEliminarEcosistema.Eliminar(ecosistema);
                TempData["MensajeExito"] = "Se eliminó el ecosistema";
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return View(ecosistema);
            }            
        }

        #endregion

        #region 8) Asignar una especie a un ecosistema

        /* Se elige una especie, se elige un ecosistema y se asocian. 
           Ese ecosistema debe ser alguno de los apropiados para la supervivencia de la especie. 
           Cada especie puede ser asociada una única vez a un ecosistema. 
           Una especie no puede ser asociada a un ecosistema que sufra las mismas amenazas que 
           sufre esa especie pues no sobrevive. 
           Asimismo, se verificará que el estado de conservación del ecosistema no sea peor que 
           el de la especie que se le está asociando.
         */

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult AsignarEspecie()
        {
            AsignarEspecieViewModel vm = new()
            {
                Especies    = CUListarEspecies.Listar(),
                Ecosistemas = CUListarEcosistemas.Listar()
            };

            return View(vm);
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult AsignarEspecie(AsignarEspecieViewModel vm)
        {
            try
            {
                Especie especie = new() { Id = vm.IdEspecieSeleccionada };
                Ecosistema ecosistema = new() { Id = vm.IdEcosistemaSeleccionado };

                ecosistema.Especies = new List<Especie>() { especie };

                CUAsignarEspecieEcosistema.AsignarEspecie(ecosistema);

                TempData["MensajeExito"] = "Se asignó la especie";

                return RedirectToAction("AsignarEspecie", "Ecosistema");
            }
            catch (Exception ex)
            {
                vm.Especies    = CUListarEspecies.Listar();
                vm.Ecosistemas = CUListarEcosistemas.Listar();

                ViewBag.MensajeError = ex.Message;
                return View(vm);
            }
        }
        

            #endregion

        }
}
