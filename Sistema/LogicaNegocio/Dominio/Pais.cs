using ExcepcionesPropias;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pais : IValidable
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
        [MinLength( 2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string Nombre { get; set; }
        public string Codigo { get; set; }        

        public IEnumerable<Ecosistema> Ecosistemas { get; set; }

        public Pais()
        {            
        }

        public void Validar()
        {
            ValidarDatosVacios();
            ValidarCodigoALpha();
        }

        public void ValidarDatosVacios()
        {
            if (Id == default
            || string.IsNullOrEmpty(Nombre)
            || string.IsNullOrEmpty(Codigo)
            )
            {
                throw new PaisException("No pueden haber datos vacios");
            }
        }

        public void ValidarCodigoALpha()
        {
            Regex regex = new Regex("^[A-Z]{3}$"); // Expresión regular para validar el formato

            if (!regex.IsMatch(Codigo))
            {
                throw new PaisException("El código ingresado no cumple con el formato ISO Alpha-3 (deben ser 3 letras mayúsculas).");
            }
        }
    }
}

