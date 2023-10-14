using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class EspecieMarina : IValidable
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres"), MinLength(2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string NombreCientifico { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres"), MinLength(2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string NombreVulgar { get; set; }

        [MaxLength(500, ErrorMessage = "La descripcion debe tener como maximo 500 caracteres"), MinLength(50, ErrorMessage = "La descripcion debe tener como minimo 50 caracteres")]
        public string Descripcion { get; set; }

        public string RangoPeso { get; set; }

        public string RangoLongitud  { get; set; }

        public List<Amenaza> Amenazas { get; set; }

        public EstadoConservacion Estado{ get; set; }

        public EspecieMarina(     )
        {
            
        }

        public void Validar()
        {
            ValidarDatosVacios();
            ValidarExtencionDeDescripcion();
        }

        public void ValidarDatosVacios()
        {
            if (Id == default
            || string.IsNullOrEmpty(NombreCientifico)
            || string.IsNullOrEmpty(Descripcion)
            || string.IsNullOrEmpty(RangoPeso)
             || string.IsNullOrEmpty(RangoLongitud)
            )
            {
                throw new Exception("No pueden haber datos vacios");
            }
        }

        public void ValidarExtencionDeDescripcion()
        {
            if (Descripcion.Length < 50 || Descripcion.Length > 500)
            {
                throw new Exception("El largo de la descripcion debe ser menor de 500 caracteres y mayor de 50");
            }
        }
    }
}
