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
    public class CUEliminarEcosistema : IEliminarEcosistema
    {
        public IRepositorioEcosistema Repositorio { get; set; }

        public CUEliminarEcosistema (IRepositorioEcosistema repositorio)
        {
            Repositorio = repositorio;
        }

        public void Eliminar(Ecosistema ecosistema)
        {
            Repositorio.Remove(ecosistema);
        }
    }
}
