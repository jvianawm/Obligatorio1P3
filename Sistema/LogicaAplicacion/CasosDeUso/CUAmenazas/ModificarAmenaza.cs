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
    public class ModificarAmenaza: IModificarAmenaza
    {
        public IRepositorioAmenaza repoAmenaza { get; set; }

        public ModificarAmenaza(IRepositorioAmenaza repositorioAmenaza)
        {
            this.repoAmenaza = repositorioAmenaza;
        }


        public void Modificar(Amenaza amenaza)
        {
            throw new NotImplementedException();
        }
    }
}
