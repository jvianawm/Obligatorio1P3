using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class AltaEcosistema :IAltaEcosistema
    {
        public IRepositorioEcosistema Repo { get; set; }

        public AltaEcosistema (IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public void Alta(Ecosistema ecosistema)
        {
           Repo.Add(ecosistema);
        }
    }
}
