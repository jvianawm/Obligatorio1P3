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
    public class CUBuscarEcosistemasPorEspecieId : IBuscarEcosistemasPorEspecieId
    {
        public IRepositorioEcosistema Repo { get; set; }

        public CUBuscarEcosistemasPorEspecieId(IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public IEnumerable<Ecosistema> Buscar(int id)
        {
            return Repo.FindByEcosistemaId(id);
        }
    }
}
