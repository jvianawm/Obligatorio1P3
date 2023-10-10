using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarEcosistema : IListarEcosistemas
    {

        public IRepositorioEcosistema Repo { get; set; }

        public ListarEcosistema (IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public IEnumerable<Ecosistema> Listar()
        {
           return Repo.FindAll();
        }
    }
}
