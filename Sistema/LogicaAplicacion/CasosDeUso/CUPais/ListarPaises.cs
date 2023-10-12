using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarPaises : IListarPais
    {

        public IRepositorioPais Repo { get; set; }
        public ListarPaises(IRepositorioPais repo)
        {
            Repo = repo;
        }

            public IEnumerable<Pais> Listar()
        {
            return Repo.FindAll();
        }
    }
}
