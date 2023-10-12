using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class BajaEstado : IBajaEstadoConservacion
    {
        public IRepositorioEstadoConservacion Repo { get; set; }

        public BajaEstado (IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

        public void Eliminar(EstadoConservacion estado)
        {
           Repo.Remove(estado); 
        }
    }
}
