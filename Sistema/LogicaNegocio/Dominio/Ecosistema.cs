using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LogicaNegocio.Dominio
{
    public class Ecosistema : IValidable
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
        [MinLength( 2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string Nombre { get; set; }
        
        public int Area { get; set; }

        [MaxLength(500, ErrorMessage = "La descripcion debe tener como maximo 500 caracteres")]
        [MinLength( 50, ErrorMessage = "La descripcion debe tener como minimo 50 caracteres")]
        public string DescripcionCaracteristicas { get; set; }

        public ICollection<Especie> Especies { get; set; }

        public ICollection<Especie> EspeciesPosibles { get; set; }

        public ICollection<Amenaza> Amenazas { get; set; }

        public ICollection<Pais> Paises { get; set; }

        public EstadoConservacion EstadoConservacion { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitud { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitud { get; set; }

        public string ArchivoImagen { get; set; }

        // Constructor
        public Ecosistema() { }

        public Ecosistema(
            string nombre,
            string descripcionCaracteristicas,
            ICollection<Especie> especies,
            ICollection<Amenaza> amenazas,
            ICollection<Pais> paises,
            EstadoConservacion estado,
            decimal longitud,
            decimal latitud,
            string archivoImagen
        )
        {
            Nombre = nombre;
            DescripcionCaracteristicas = descripcionCaracteristicas;
            Especies = especies;
            Amenazas = amenazas;
            Paises = paises;
            EstadoConservacion = estado;
            Longitud = longitud;
            Latitud = latitud;
            ArchivoImagen = archivoImagen;
        }

        public void Validar()
        {
            ValidarDatosVacios();
            ValidarExtencionDeDescripcion();
            ValidarLongitud();
            ValidarLatitud();
            ValidarArea();
            ValidarArchivoImagen();
        }

        public void ValidarDatosVacios()
        {
            if (string.IsNullOrEmpty(DescripcionCaracteristicas)
             || string.IsNullOrEmpty(Nombre)
             || string.IsNullOrEmpty(ArchivoImagen)
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

        public void ValidarLatitud()
        {
            if (Latitud < -90 || Latitud > 90)
            {
                throw new EcosistemaException("La latitud debe estar en el rango de -90 a 90 grados");
            }
        }

        public void ValidarLongitud()
        {
            if (Longitud < -180 || Longitud > 180)
            {
                throw new EcosistemaException("La longitud debe estar en el rango de -180 a 180 grados");
            }
        }

        public void ValidarArea()
        {
            if (Area < 0)
            {
                throw new EcosistemaException("El área no puede ser un número negativo");
            }
        }

        public void ValidarArchivoImagen()
        {
            if (ArchivoImagen == null)
            {
                throw new Exception("La imágen del ecosistema es requerida");
            }
        }
    }
}
