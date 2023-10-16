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
    public class CUListarAmenazas: IListarAmenazas
    {
        public IRepositorioAmenaza repositorioAmenaza { get; set; }

        public CUListarAmenazas(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }

        public IEnumerable<Amenaza> Listar()
        {
            return repositorioAmenaza.FindAll();
        }

        public IEnumerable<Amenaza> FindByIds(List<int> ids)
        {
            return repositorioAmenaza.FindByIds(ids);
        }
    }
}
