using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class ConsultaEspecieViewModel
    {
        // Ecosistemas
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        public IEnumerable<Ecosistema> EcosistemasEspecieNoPuedeHabitar { get; set; }

        // Especies
        public Especie Especie { get; set; }
        public IEnumerable<Especie> Especies { get; set; }
        public IEnumerable<Especie> EspeciesEnPeligro { get; set; }
        public IEnumerable<Especie> EspeciesPorEcosistema { get; set; }
        public int IdEspecieSeleccionada { get; set; }

        

        public string RutaDirectorioImagenesEspecies { get; set; }
        public string RutaDirectorioImagenesEcosistemas { get; set; }

        public string TipoDeConsulta { get; set; }        

        public int IdNombreCientifico { get; set; }

        public int IdPorEcosistema { get; set; }

        public int IdNoPuedeHabitar { get; set; }
        


    }
}
