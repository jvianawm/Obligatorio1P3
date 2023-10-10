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
    public class ListarEspecies: IListarEspecies
    {
        public IRepositorioEspecieMarina Repo { get; set; }

        public ListarEspecies (IRepositorioEspecieMarina repo)
        {
            Repo = repo;
        }

        public IEnumerable<EspecieMarina> Listar()
        {
            return Repo.FindAll();
        }
    }
}
