using ExcepcionesPropias;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEcosistema : IRepositorioEcosistema
    {

        public PlataformaContext Context { get; set; }

        public RepositorioEcosistema(PlataformaContext context)
        {
            Context = context;
        }


        public void Add(Ecosistema ecosistema)
        {
            if (ecosistema != null)
            {
                ecosistema.Validar();

                bool yaExiste = Context.Ecosistemas.Where(
                                   e => e.Nombre.Trim().ToLower() == ecosistema.Nombre.Trim().ToLower()
                                ).Any();

                if (yaExiste)
                {
                    throw new UsuarioException("Ya existe un ecosistema con ese nombre");
                }

                Context.Ecosistemas.Add(ecosistema);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un ecosistema");
            }
        }















        
        public IEnumerable<Ecosistema> FindAll()
        {
            throw new NotImplementedException();
        }

        public Ecosistema FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Ecosistema obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
    }
}
