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
    public class CUBuscarEcosistemaPorId: IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema Repo { get; set; }    

        public CUBuscarEcosistemaPorId(IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public Ecosistema Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
