using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LogicaNegocio
{
    public class Ecosistema : IValidable
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
        [MinLength( 2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string Nombre { get; set; }

        [MinLength( 0, ErrorMessage ="El area no puede ser menor a 0")]
        public int Area { get; set; }

        [MaxLength(500, ErrorMessage = "La descripcion debe tener como maximo 500 caracteres")]
        [MinLength( 50, ErrorMessage = "La descripcion debe tener como minimo 50 caracteres")]
        public string DescripcionCaracteristicas { get; set; }

        public IEnumerable<EspecieMarina> EspecieMarinas { get; set; }

        public IEnumerable<Amenaza> Amenazas { get; set; }       

        public IEnumerable<Pais> Paises { get; set; }

        public EstadoConservacion Estado { get; set; }

        public decimal Longitud { get; set; }

        public decimal Latitud { get; set; }

        // Constructor
        public Ecosistema() { }

        public Ecosistema(
            string nombre,
            string descripcionCaracteristicas,
            IEnumerable<EspecieMarina> especies,
            IEnumerable<Amenaza> amenazas,
            IEnumerable<Pais> paises,
            EstadoConservacion estado,
            decimal longitud,
            decimal latitud)
        {
            Nombre = nombre;
            DescripcionCaracteristicas = descripcionCaracteristicas;
            EspecieMarinas = especies;
            Amenazas = amenazas;
            Paises = paises;
            Estado = estado;
            Longitud = longitud;
            Latitud = latitud;
        }

        public void Validar()
        {
            ValidarDatosVacios();
            ValidarExtencionDeDescripcion();
        }

        public void ValidarDatosVacios()
        {

            if (Id == default
            || string.IsNullOrEmpty(DescripcionCaracteristicas)
            || string.IsNullOrEmpty(Nombre)
            )
            {
                throw new EcosistemaException("No pueden haber datos vacios");
            }
        }

        public void ValidarExtencionDeDescripcion()
        {
            if (DescripcionCaracteristicas.Length < 50 || DescripcionCaracteristicas.Length > 500)
            {
                throw new EcosistemaException("El largo de la descripcion debe ser menor de 500 caracteres y mayor de 50");
            }
        }
    }
}
