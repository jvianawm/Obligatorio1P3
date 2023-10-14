using LogicaNegocio;
using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresetacionMVC.Models
{
    public class RegistroEcosistemaViewModel
    {
        public Ecosistema Ecosistema { get; set; }

        public IEnumerable<Pais> Paises { get; set; }
        public int[] IdsPaisesSeleccionados { get; set; }

        public IEnumerable<Pais> Amenazas { get; set; }
        public int[] IdsAmenazasSeleccionadas { get; set; }

        public IEnumerable<EspecieMarina> Especies { get; set; }
        public int[] IdsEspeciesSeleccionadas { get; set; }



        /*
        public Usuario Usuario { get; set; }
        [MinLength(8, ErrorMessage = "La contraseña confirmada debe tener minimo 8 caracteres")]
        [Required(ErrorMessage = "La contraseña confirmada es un dato requerido")]
        [DisplayName("Confirmar contraseña")]
        public string ClaveConfirmada { get; set; }
        */
    }
}
