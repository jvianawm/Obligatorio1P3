using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class AsignarEspecieViewModel
    {
        // Ecosistemas
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        public int IdEcosistemaSeleccionado { get; set; }       

        // Especies
        public IEnumerable<Especie> Especies { get; set; }
        public int IdEspecieSeleccionada { get; set; }
    }
}
