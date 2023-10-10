using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarAmenaza: IListarAmenaza
    {
        public IRepositorioAmenaza repositorioAmenaza { get; set; }

        public ListarAmenaza(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }

        public IEnumerable<Amenaza> Listar()
        {
            return repositorioAmenaza.FindAll();
        }
    }
}
