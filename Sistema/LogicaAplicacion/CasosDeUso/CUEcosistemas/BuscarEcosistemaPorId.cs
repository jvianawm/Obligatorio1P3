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
    public class BuscarEcosistemaPorId: IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema Repo { get; set; }    

        public BuscarEcosistemaPorId(IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public Ecosistema Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
