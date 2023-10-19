using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class RegistroEspecieViewModel
    {
        public Especie Especie { get; set; }

        // Amenazas
        public IEnumerable<Amenaza> Amenazas { get; set; }
        public int[] IdsAmenazasSeleccionadas { get; set; }

        // Ecosistemas
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        public int[] IdsEcosistemasSeleccionados { get; set; }


        // Ecosistemas Posibles
        public IEnumerable<Ecosistema> EcosistemasPosibles { get; set; }
        public int[] IdsEcosistemasPosiblesSeleccionados { get; set; }

        public IFormFile ArchivoImagen { get; set; }

        // Estados
        public IEnumerable<EstadoConservacion> Estados { get; set; }
        public int IdEstado { get; set; }

    }
}
