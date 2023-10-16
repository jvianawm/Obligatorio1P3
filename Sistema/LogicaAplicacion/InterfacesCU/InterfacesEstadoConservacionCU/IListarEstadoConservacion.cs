using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListarEstadoConservacion
    {
        public IEnumerable<EstadoConservacion> Listar();

        public EstadoConservacion ObtenerPorId(int id);
    }
}