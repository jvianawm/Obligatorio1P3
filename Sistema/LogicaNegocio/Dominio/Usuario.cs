using ExepcionesPropias;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio
{
   public class Usuario : IValidable
    {
       

 
        public int Id { get; set; }

        [MinLength(6, ErrorMessage = "El alias debe contener minimo 6 caracteres")]

        public string Alias { get; set; }

        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8  caracteres")]
        public string Password { get; set; }

        public DateTime FechaIngreso { get; set; }


        public Usuario()
        {
               
        }

        public void Validar()
        {
            ValidarDatosVacios(Alias, Password);
            ValidarFecha();

        }

    

        public  void ValidarDatosVacios( string alias, string password)
        {
            bool hayVacio = string.IsNullOrEmpty(alias)
                         || string.IsNullOrEmpty(password);

            if (hayVacio)
            {
                throw new UsuarioException("Todos los datos del usuario son requeridos");
            }
        }

        public void ValidarFecha()
        {
            if (FechaIngreso == default)
            {
                throw new UsuarioException("Se debe definir una fecha válida");
            }
        }

    }
}
