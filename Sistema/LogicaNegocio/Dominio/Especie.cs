using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Especie : IValidable
    {
        public int Id { get; set; }

        [Column("NombreCientifico")]
        public NombreCientifico NombreCientifico { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
        [MinLength( 2, ErrorMessage = "El nombre debe tener como minimo 2 caracteres")]
        public string NombreVulgar { get; set; }

        public DescripcionEspecie Descripcion { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal PesoMinimo { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal PesoMaximo { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? LongitudMinima { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? LongitudMaxima { get; set; }

        public ICollection<Amenaza> Amenazas { get; set; }

        public EstadoConservacion EstadoConservacion { get; set; }

        //[InverseProperty("Especies")]
        public ICollection<Ecosistema> Ecosistemas { get; set; }

        //[InverseProperty("EspeciesPosibles")]
        public ICollection<Ecosistema> EcosistemasPosibles { get; set; }

        public string ArchivoImagen { get; set; }

        public Especie(     )
        {
            
        }

        public void Validar()
        {
            ValidarPeso();
            ValidarLongitud();
            ValidarArchivoImagen();
        }

        public void ValidarPeso()
        {
            if(PesoMinimo >= PesoMaximo)
            {
                throw new Exception("El peso mínimo no puede ser mayor o igual al máximo");
            }

            if (PesoMinimo < 0)
            {
                throw new Exception("El peso mínimo no puede ser negativo");
            }

            if (PesoMaximo < 0)
            {
                throw new Exception("El peso máximo no puede ser negativo");
            }
        }

        public void ValidarLongitud()
        {
            if (LongitudMinima >= LongitudMaxima)
            {
                throw new Exception("La longitud mínima no puede ser mayor o igual la máxima");
            }
        }
        public void ValidarArchivoImagen()
        {
            if (ArchivoImagen == null)
            {
                throw new Exception("La imágen de la especie es requerida");
            }
        }
    }
}
