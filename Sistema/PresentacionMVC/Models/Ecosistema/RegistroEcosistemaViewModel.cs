using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class RegistroEcosistemaViewModel
    {
        public Ecosistema Ecosistema { get; set; }

        // Paises
        public IEnumerable<Pais> Paises { get; set; }
        public int[] IdsPaisesSeleccionados { get; set; }

        // Amenazas
        public IEnumerable<Amenaza> Amenazas { get; set; }
        public int[] IdsAmenazasSeleccionadas { get; set; }

        // Especies
        public IEnumerable<Especie> Especies { get; set; }
        public int[] IdsEspeciesSeleccionadas { get; set; }

        // Estados
        public IEnumerable<EstadoConservacion> Estados { get; set; }
        public int IdEstado { get; set; }

        public IFormFile ArchivoImagen { get; set; }
    }
}
