using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListarAmenazas
    {
        public IEnumerable<Amenaza> Listar();

        public IEnumerable<Amenaza> FindByIds(List<int> ids);
    }
}
