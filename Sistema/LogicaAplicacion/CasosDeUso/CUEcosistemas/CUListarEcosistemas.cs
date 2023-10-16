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
    public class CUListarEcosistemas : IListarEcosistemas
    {

        public IRepositorioEcosistema Repo { get; set; }

        public CUListarEcosistemas (IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public IEnumerable<Ecosistema> Listar()
        {
           return Repo.FindAll();
        }

        public IEnumerable<Ecosistema> FindByIds(List<int> ids)
        {
            return Repo.FindByIds(ids);
        }
    }
}
