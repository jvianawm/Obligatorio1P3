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
    public class BuscarAmenazaPorId : IBuscarAmenazaPorId
    {

        public IRepositorioAmenaza repositorioAmenaza { get; set; }

        public BuscarAmenazaPorId(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }


        public Amenaza Buscar(int id)
        {
           return repositorioAmenaza.FindById(id);
        }
    }
}
