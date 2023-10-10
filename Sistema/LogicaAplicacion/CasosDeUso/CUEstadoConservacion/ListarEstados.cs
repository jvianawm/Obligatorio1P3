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
    public class ListarEstados : IListarEstadoConservacion
    {
        public IRepositorioEstadoConservacion Repo { get; set; }

        public ListarEstados(IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

        public IEnumerable<EstadoConservacion> Listar()
        {
            return Repo.FindAll();  
        }
    }

 
    }
}
