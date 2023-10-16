using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListarPaises
    {
        public IEnumerable<Pais> Listar();

        public IEnumerable<Pais> FindByIds(List<int> ids);
    }
}
