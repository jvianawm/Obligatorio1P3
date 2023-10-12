using LogicaNegocio;
using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresetacionMVC.Models
{
    public class RegistroUsuarioViewModel
    {
        public Usuario Usuario { get; set; }

        [MinLength(8, ErrorMessage = "La contraseña confirmada debe tener minimo 8 caracteres")]
        [Required(ErrorMessage = "La contraseña confirmada es un dato requerido")]
        [DisplayName("Confirmar contraseña")]
        public string  ClaveConfirmada { get; set; }
    }
}
