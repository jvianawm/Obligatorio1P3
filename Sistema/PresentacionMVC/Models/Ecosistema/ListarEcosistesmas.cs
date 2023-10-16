using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class ListarEcosistemasViewModel
    {
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }

        public string RutaDirectorioImagenes { get; set; }
    }
}
