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
    public class CUListarEstados : IListarEstadoConservacion
    {
        public IRepositorioEstadoConservacion Repo { get; set; }

        public CUListarEstados(IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

        public IEnumerable<EstadoConservacion> Listar()
        {
            return Repo.FindAll();
        }

        public EstadoConservacion ObtenerPorId(int id)
        {
            return Repo.FindById(id);
        }
    }    
}
