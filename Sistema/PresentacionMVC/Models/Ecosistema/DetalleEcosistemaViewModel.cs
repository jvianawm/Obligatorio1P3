using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class DetalleEcosistemaViewModel
    {
        // Ecosistemas
        public Ecosistema Ecosistema { get; set; }
        
        public IEnumerable<Especie> Especies { get; set; }        

        public string RutaDirectorioImagenesEspecies { get; set; }
        public string RutaDirectorioImagenesEcosistemas { get; set; }
    }
}
