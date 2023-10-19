using ExcepcionesPropias;
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
using System.Security.Cryptography;

namespace LogicaNegocio.Dominio
{
   public class Usuario : IValidable
    {       
        public int Id { get; set; }

        [MinLength(6, ErrorMessage = "El alias debe contener minimo 6 caracteres")]
        [Required(ErrorMessage ="El alias es un dato requerido")]        
        public string Alias { get; set; }

        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8  caracteres")]
        [Required(ErrorMessage = "La contraseña es un dato requerido")]
        public string Password { get; set; }

        [MaxLength(64)]
        public string PasswordEncriptado { get; set; }

        public DateTime FechaIngreso { get; set; }

        public Usuario()
        {
        }

        public static string EncriptarPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public void Validar()
        {
            ValidarDatosVacios(Alias, Password);
            ValidarFechaIngreso();
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

        public void ValidarFechaIngreso()
        {
            if (FechaIngreso == default)
            {
                throw new UsuarioException("Se debe definir una fecha válida");
            }
        }

        public static void ValidarPassword(string password)
        {
            // Verificar si tiene al menos 8 caracteres
            if (password.Length < 8)
            {
                throw new UsuarioException("La contraseña debe tener por lo menos 8 caracteres");
            }

            // Verificar si contiene al menos una mayúscula, una minúscula y un dígito
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                throw new UsuarioException("La contraseña debe contener al menos una mayúscula, una minúscula y un dígito");
            }

            // Verificar si contiene al menos un carácter especial de los especificados
            string caracteresEspeciales = @".,;:#!";
            if (!password.Any(caracteresEspeciales.Contains))
            {
                throw new UsuarioException("La contraseña debe contener al menos un carácter especial de los especificados (.,;:#!)");
            }
        }
    }
}
