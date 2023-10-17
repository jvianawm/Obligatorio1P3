using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class DetalleEspecieViewModel
    {
        // Ecosistemas
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        //public int[] IdsEcosistemasSeleccionados { get; set; }

        public IEnumerable<Especie> Especies { get; set; }
        //public int[] IdsEspeciesSeleccionados { get; set; }

        public string RutaDirectorioImagenesEspecies { get; set; }
        public string RutaDirectorioImagenesEcosistemas { get; set; }
    }
}
