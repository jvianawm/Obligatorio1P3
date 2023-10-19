using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using PresentacionMVC.Filters;

using PresentacionMVC.Models;
using Humanizer;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Microsoft.AspNetCore.Hosting;


namespace PresentacionMVC.Controllers
{
    public class EspeciesController : Controller
    {        
        public IListarAmenazas CUListarAmenazas { get; set; }
        public IListarEcosistemas CUListarEcosistemas { get; set; }
        public IRegistroEspecie CURegistroEspecie { get; set; }
        public IListarEstadoConservacion CUListarEstados { get; set; }
        public IListarEspecies CUListarEspecies { get; set; }
        public IBuscarEspeciePorId CUBuscarEspeciePorId { get; set; }
        public IBuscarEcosistemaPorId CUBuscarEcosistemaPorId { get; set; }
        public IBuscarEcosistemasPorEspecieId CUBuscarEcosistemasPorEspecieId { get; set; }
        public IListarEspeciesEnPeligro CUListarEspeciesEnPeligro { get; set; }
        public IEcosistemasEspecieNoPuedeHabitar CUEcosistemasEspecieNoPuedeHabitar { get; set; }
        public IBuscarPorRangoPeso CUBuscarPorRangoPeso { get; set; }        
        public IModificarMaxCharNombreCientifico CUModificarMaxCharNomCientifico { get; set; }
        public IModificarMinCharNombreCientifico CUModificarMinCharNomCientifico { get; set; }
        public IModificarMaxCharDescripcionEspecie CUModificarMaxCharDescripcionEspecie { get; set; }
        public IModificarMinCharDescripcionEspecie CUModificarMinCharDescripcionEspecie { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public EspeciesController(
            IListarAmenazas cuListarAmenazas,
            IListarEcosistemas cuListarEcosistemas,
            IRegistroEspecie cuRegistroEspecie,
            IListarEstadoConservacion cuListarEstados,
            IListarEspecies cuListarEspecies,
            IBuscarEspeciePorId cuBuscarEspeciePorId,
            IBuscarEcosistemaPorId cuBuscarEcosistemaPorId,
            IBuscarEcosistemasPorEspecieId cuBuscarEcosistemaPorEspecieId,
            IListarEspeciesEnPeligro cuListarEspeciesEnPeligro,
            IEcosistemasEspecieNoPuedeHabitar cuEcosistemasEspecieNoPuedeHabitar,
            IBuscarPorRangoPeso cuBuscarPorRangoPeso,
            IModificarMaxCharNombreCientifico cuModificarMaxCharNomCientifico,
            IModificarMinCharNombreCientifico cuModificarMinCharNomCientifico,
            IModificarMaxCharDescripcionEspecie cuModificarMaxCharDescripcionEspecie,
            IModificarMinCharDescripcionEspecie cuModificarMinCharDescripcionEspecie,            
            IWebHostEnvironment webHostEnvironment
        )
        {
            CUListarAmenazas = cuListarAmenazas;
            CUListarEcosistemas = cuListarEcosistemas;
            CURegistroEspecie = cuRegistroEspecie;
            CUListarEstados = cuListarEstados;
            CUListarEspecies = cuListarEspecies;
            CUBuscarEspeciePorId = cuBuscarEspeciePorId;
            CUBuscarEcosistemaPorId = cuBuscarEcosistemaPorId;
            CUBuscarEcosistemasPorEspecieId = cuBuscarEcosistemaPorEspecieId;
            CUListarEspeciesEnPeligro = cuListarEspeciesEnPeligro;
            CUEcosistemasEspecieNoPuedeHabitar = cuEcosistemasEspecieNoPuedeHabitar;
            CUBuscarPorRangoPeso = cuBuscarPorRangoPeso;
            CUModificarMaxCharNomCientifico = cuModificarMaxCharNomCientifico;
            CUModificarMinCharNomCientifico = cuModificarMinCharNomCientifico;
            CUModificarMaxCharDescripcionEspecie = cuModificarMaxCharDescripcionEspecie;
            CUModificarMinCharDescripcionEspecie = cuModificarMinCharDescripcionEspecie;
            WebHostEnvironment = webHostEnvironment;
        }
        

        #region 5) Registro de especies.
        /* Al registrar una especie, además de los datos anteriores se permitirá seleccionar uno o más ecosistemas en los que puede habitar dadas sus características.
           No significa que efectivamente lo habite, solamente que su vida en ese ecosistema es posible.
           Se asume que quien esté cargando la información tiene el conocimiento suficiente para decidir cuáles son los ecosistemas apropiados para una especie.
        */
        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult Registro()
        {            
            RegistroEspecieViewModel vm = new()
            {                
                Amenazas            = CUListarAmenazas.Listar(),
                Ecosistemas         = CUListarEcosistemas.Listar(),
                EcosistemasPosibles = CUListarEcosistemas.Listar(),
                Estados             = CUListarEstados.Listar()
            };
            
            return View(vm);
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult Registro(RegistroEspecieViewModel vm)
        {
            try
            {
                vm.Especie.Amenazas            = CUListarAmenazas.FindByIds(vm.IdsAmenazasSeleccionadas.ToList()).ToList();
                vm.Especie.Ecosistemas         = CUListarEcosistemas.FindByIds(vm.IdsEcosistemasSeleccionados.ToList()).ToList();
                vm.Especie.EcosistemasPosibles = CUListarEcosistemas.FindByIds(vm.IdsEcosistemasPosiblesSeleccionados.ToList()).ToList();
                vm.Especie.EstadoConservacion = CUListarEstados.ObtenerPorId(vm.IdEstado);

                FileInfo imagen = new FileInfo(vm.ArchivoImagen.FileName);
                string extension = imagen.Extension;

                if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                {
                    throw new Exception("El tipo de imagen debe ser png o jpg");
                }

                string nombreArchivo = vm.Especie.NombreCientifico + extension;
                vm.Especie.ArchivoImagen = nombreArchivo;

                CURegistroEspecie.Registrar(vm.Especie);

                if (vm.ArchivoImagen != null && vm.ArchivoImagen.Length > 0)
                {
                    string directorio = WebHostEnvironment.WebRootPath;
                    string rutaCompleta = Path.Combine(directorio, "img", "especies", nombreArchivo);

                    FileStream fileStream = new FileStream(rutaCompleta, FileMode.Create);
                    vm.ArchivoImagen.CopyTo(fileStream);
                }

                TempData["MensajeExito"] = "Se creó la especie " + vm.Especie.NombreCientifico;
                return RedirectToAction("Registro", "Especies");
            }
            catch (Exception ex)
            {
                vm.Amenazas = CUListarAmenazas.Listar();
                vm.Ecosistemas = CUListarEcosistemas.Listar();
                vm.EcosistemasPosibles = CUListarEcosistemas.Listar();
                vm.Estados = CUListarEstados.Listar();

                ViewBag.MensajeError = ex.Message;
                return View(vm);

            }            
        }

        #endregion

        #region 6 ) Modificar los topes del largo de la descripción y del nombre.
        /* Se permitirá modificar el largo de las descripciones y de los nombres, 
           siempre que no se pierda información de los nombres o descripciones ya almacenados. 
           Se modifican de a uno por vez.         
         */

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult ModificarMaximoNombreCientifico()
        {
            return View();
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult ModificarMaximoNombreCientifico(int valor)
        {            
            try
            {
                CUModificarMaxCharNomCientifico.Modificar(valor);

                TempData["MensajeExito"] = "Se modificó el máximo del nombre científico ";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(valor);
        }

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult ModificarMinimoNombreCientifico()
        {
            return View();
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult ModificarMinimoNombreCientifico(int valor)
        {
            try
            {
                CUModificarMinCharNomCientifico.Modificar(valor);

                TempData["MensajeExito"] = "Se modificó el mínimo del nombre científico ";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(valor);
        }


        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult ModificarMinimoDescripcionEspecie()
        {
            return View();
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult ModificarMinimoDescripcionEspecie(int valor)
        {
            try
            {
                CUModificarMinCharDescripcionEspecie.Modificar(valor);

                TempData["MensajeExito"] = "Se modificó el mínimo de la descripción de la especie ";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(valor);
        }

        [HttpGet]
        [UsuarioAutenticado]
        public ActionResult ModificarMaximoDescripcionEspecie()
        {
            return View();
        }

        [HttpPost]
        [UsuarioAutenticado]
        public ActionResult ModificarMaximoDescripcionEspecie(int valor)
        {
            try
            {
                CUModificarMaxCharDescripcionEspecie.Modificar(valor);

                TempData["MensajeExito"] = "Se modificó el mínimo de la descripción de la especie ";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
            }

            return View(valor);
        }

        

        #endregion

        #region 9) Consulta de especies.
       /*
           Se podrán filtrar las especies y visualizarlas.
               - Se desplegarán todos sus datos, incluyendo su foto y 
               - los datos de los ecosistemas que habita (El ecosistema también incluirá su foto.)

           Cuando no se incluyan filtros, se mostrarán todas las especies.

           La búsqueda se podrá realizar por los siguientes criterios (restrictivos):
               - Por nombre científico.
               - Especies en peligro de extinción (las que su estado de conservación sea menor que 60, también las que sufran más de 3 amenazas o también si habitan un ecosistema que sufra más de 3 amenazas siempre que ese ecosistema tenga un grado de conservación menor que 60).
               - Especies en un rango determinado de peso.
               - Por ecosistema: las especies que habitan ese ecosistema(no las que pueden habitarlo, sino las que efectivamente lo habitan).
               - Dada una especie, todos los ecosistemas en los que no puede habitar.
       */

       [HttpGet]
        //[UsuarioAutenticado]
        public ActionResult Consultas()
        {
            ConsultaEspecieViewModel vm = new(){};

            vm.TipoDeConsulta    = "todasEspecies";
            vm.Ecosistemas       = CUListarEcosistemas.Listar();
            vm.Especies          = CUListarEspecies.Listar();
            vm.EspeciesEnPeligro = CUListarEspeciesEnPeligro.Listar();

            vm.RutaDirectorioImagenesEcosistemas = Path.Combine("img", "ecosistemas");
            vm.RutaDirectorioImagenesEspecies    = Path.Combine("img", "especies");

            return View(vm);
        }

        [HttpPost]
        //[UsuarioAutenticado]
        public ActionResult Consultas(ConsultaEspecieViewModel vm)
        {
            vm.Especies = CUListarEspecies.Listar();
            vm.Ecosistemas = CUListarEcosistemas.Listar();
            vm.EspeciesEnPeligro = CUListarEspeciesEnPeligro.Listar();
                       
            if (vm.TipoDeConsulta == "nombreCientifico")
            {
                vm.Especie = CUBuscarEspeciePorId.Buscar(vm.IdNombreCientifico);
                vm.Ecosistemas = CUBuscarEcosistemasPorEspecieId.Buscar(vm.Especie.Id);
            }

            if (vm.TipoDeConsulta == "porEcosistema") 
            {
                vm.EspeciesPorEcosistema = CUBuscarEcosistemaPorId.Buscar(vm.IdPorEcosistema).Especies;
            }

            if (vm.TipoDeConsulta == "noPuedeHabitar") 
            { 
                vm.EcosistemasEspecieNoPuedeHabitar = CUEcosistemasEspecieNoPuedeHabitar.Buscar(vm.IdNoPuedeHabitar);
            }

            if (vm.TipoDeConsulta == "rangoPeso")
            {
                vm.EspeciesPorRangoPeso = CUBuscarPorRangoPeso.Buscar(vm.Especie.PesoMinimo, vm.Especie.PesoMaximo);
            }

            vm.RutaDirectorioImagenesEcosistemas = Path.Combine("img", "ecosistemas");
            vm.RutaDirectorioImagenesEspecies = Path.Combine("img", "especies");

            return View(vm);
        }

        [HttpGet]
        //[UsuarioAutenticado]
        public ActionResult Detalles(int id)
        {
            ConsultaEspecieViewModel vm = new()
            {
                Ecosistemas = CUListarEcosistemas.Listar(),
                Especies = CUListarEspecies.Listar(),
            };

            vm.RutaDirectorioImagenesEcosistemas = Path.Combine("img", "ecosistemas");
            vm.RutaDirectorioImagenesEspecies = Path.Combine("img", "especies");

            return View(vm);
        }

        #endregion
    }

}
