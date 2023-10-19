using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
    {
        public IEnumerable<Ecosistema> FindByIds(List<int> ids);

        public IEnumerable<Ecosistema> FindByEcosistemaId(int id);
     
        public void AsignarEspecie(Ecosistema ecosistema);

        public IEnumerable<Ecosistema> ObtenerEcosistemasEspecieNoPuedeHabitar(int idEspecie);
    }
}
