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
    public class BajaAmenaza : IBajaAmenaza
    {

        public IRepositorioAmenaza repositorioAmenaza { get; set; }

        public BajaAmenaza(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repositorioAmenaza = repositorioAmenaza;
        }

        public void Eliminar(Amenaza amenaza)
        {
            repositorioAmenaza.Remove(amenaza);
        }
    }
}
