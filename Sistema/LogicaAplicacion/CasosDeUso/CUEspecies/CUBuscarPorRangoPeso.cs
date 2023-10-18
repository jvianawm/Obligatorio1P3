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
    public class CUBuscarPorRangoPeso : IBuscarPorRangoPeso
    {
        public IRepositorioEspecie Repo { get; set; }

        public CUBuscarPorRangoPeso(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public IEnumerable<Especie> Buscar(decimal minimo, decimal maximo)
        {
            return Repo.FindByRangoPeso(minimo, maximo);
        }
    }
}
