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
    public class CUListarPaises : IListarPaises
    {

        public IRepositorioPais Repo { get; set; }
        public CUListarPaises(IRepositorioPais repo)
        {
            Repo = repo;
        }

        public IEnumerable<Pais> Listar()
        {
            return Repo.FindAll();
        }

        public IEnumerable<Pais> FindByIds(List<int> ids)
        {
            return Repo.FindByIds(ids);
        }
    }
}
