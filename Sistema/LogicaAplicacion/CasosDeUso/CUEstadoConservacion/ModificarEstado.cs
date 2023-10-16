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
    public class ModificarEstado: IModificarEstadoConservacion
    {
        public IRepositorioEstadoConservacion Repo { get; set; }    
        public ModificarEstado(IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

        public void Modificar(EstadoConservacion estadoConservacion)
        {
            Repo.Update(estadoConservacion);    
        }
    }
}
