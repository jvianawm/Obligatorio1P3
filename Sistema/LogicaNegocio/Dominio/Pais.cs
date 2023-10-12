using ExcepcionesPropias;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Pais : IValidable
    {
        



        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres"), MinLength(2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string Nombre { get; set; }
        public string Codigo { get; set; }


        public Pais()
        {
            
        }




        public void Validar()
        {
            ValidarDatosVacios();

        }

        public void ValidarDatosVacios()
        {

            if (Id == default
            || string.IsNullOrEmpty(Nombre)

            )
            {
                throw new PaisException("No pueden haber datos vacios");
            }
        }



        static void Main()
        {
            string codigoIsoAlpha3 = PedirCodigoIsoAlpha3();

            Console.WriteLine($"El código ISO Alpha-3 ingresado es: {codigoIsoAlpha3}");
        }

        static string PedirCodigoIsoAlpha3()
        {
            string codigoIsoAlpha3;
            Regex regex = new Regex("^[A-Z]{3}$"); // Expresión regular para validar el formato

            do
            {
                Console.Write("Ingresa un código ISO Alpha-3 válido: ");
                codigoIsoAlpha3 = Console.ReadLine().ToUpper(); // Convertir a mayúsculas para garantizar el formato

                if (!regex.IsMatch(codigoIsoAlpha3))
                {
                    Console.WriteLine("El código ingresado no cumple con el formato ISO Alpha-3 (deben ser 3 letras mayúsculas).");
                }
            } while (!regex.IsMatch(codigoIsoAlpha3));

            return codigoIsoAlpha3;
        }
    }
}

