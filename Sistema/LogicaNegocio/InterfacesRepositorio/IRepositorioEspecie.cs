using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEspecie: IRepositorio<Especie>
    {
        public IEnumerable<Especie> FindByIds(List<int> ids);

        public IEnumerable<Especie> FindEspeciesEnPeligro();

        public IEnumerable<Especie> FindByRangoPeso(decimal minimo, decimal maximo);
    }
}
