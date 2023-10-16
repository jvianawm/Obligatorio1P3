using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class EstadoConservacion : IValidable // VALE LA PENA CREAR UNA CLASE DE ESTAS??
    {      
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Range(0,100, ErrorMessage = "No puede dejar vacio este item, y el ingreso debe estar comprendido entre 0 y 100")]
        public int Estado { get; set; }


        public EstadoConservacion()
        {
            
        }

        public void Validar()
        {
            ValidarDatosVacios();
        }

        public void ValidarDatosVacios()
        {

            if (Id == default || string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No pueden haber datos vacios");
            }
        }

        public void EstadoDeConservacion()
        {

            if (Estado == default || Estado < 0 || Estado > 100)
            {
                throw new Exception("No puede dejar vacio este item, y el ingreso debe estar comprendido entre 0 y 100");
            }                
            else if(Estado >= 60 && Estado <= 70) 
            {
                throw new Exception("El estado de conservacion es aceptable");
            }
            else if (Estado > 70 && Estado <= 100)
            {
                throw new Exception("El estado de conservacion es Optimo");
            }
            else {
                throw new Exception("Mal estado de conservacion");
            }
        }



    }   
}
