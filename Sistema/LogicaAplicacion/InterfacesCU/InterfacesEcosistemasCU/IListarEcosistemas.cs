using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListarEcosistemas
    {
        IEnumerable<Ecosistema> Listar();

        public IEnumerable<Ecosistema> FindByIds(List<int> ids);
    }
}
