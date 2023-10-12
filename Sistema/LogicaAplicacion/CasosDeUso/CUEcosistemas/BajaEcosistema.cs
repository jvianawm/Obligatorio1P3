using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEcosistemas
{
    public class BajaEcosistema : IBajaEcosistema
    {
        public IRepositorioEcosistema Repositorio { get; set; }

        public BajaEcosistema (IRepositorioEcosistema repositorio)
        {
            Repositorio = repositorio;
        }

        public void Eliminar(Ecosistema ecosistema)
        {
            Repositorio.Remove(ecosistema);
        }
    }
}
