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
    public class AltaAmenaza : IAltaAmenaza
    {
        public IRepositorioAmenaza RepositorioAmenaza { get; set; }



        public AltaAmenaza (IRepositorioAmenaza repositorioAmenaza)
        {
            RepositorioAmenaza = repositorioAmenaza;
        }


        public void Alta(Amenaza amenaza)
        {
            RepositorioAmenaza.Add(amenaza);
        }
    }
}
