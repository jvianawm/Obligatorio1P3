using LogicaNegocio.Enums;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExepcionesPropias;

namespace LogicaNegocio.Dominio
{
    public class Amenaza : IValidable
    {
       


        //PROPIEDADES

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public GradoPeligrosidad GradoPeligrosidad { get; set; }



        public Amenaza()
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
            || string.IsNullOrEmpty(Descripcion)

            )
            {
                throw new AmenazaExeption("No pueden haber datos vacios");
            }
        }

        public void ValidarExtencionDeDescripcion()
        {
            if (Descripcion.Length < 50 && Descripcion.Length > 500)
            {
                throw new AmenazaExeption("El largo de la descripcion debe ser menor de 500 caracteres y mayor de 50");
            }
        }
    }
}
