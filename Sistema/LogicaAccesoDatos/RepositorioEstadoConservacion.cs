using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEstadoConservacion : IRepositorioEstadoConservacion
    {
        public PlataformaContext Context { get; set; }

        public RepositorioEstadoConservacion(PlataformaContext context)
        {
            Context = context;
        }

        public void Add(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoConservacion> FindAll()
        {
            return Context.EstadoConservacion;
        }

        public EstadoConservacion FindById(int id)
        {
            return Context.EstadoConservacion.Find(id);
        }

        public void Remove(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
