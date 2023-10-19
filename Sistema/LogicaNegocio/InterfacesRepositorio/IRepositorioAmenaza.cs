using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioAmenaza: IRepositorio<Amenaza>
    {
        public IEnumerable<Amenaza> FindByIds(List<int> ids);
    }
}
