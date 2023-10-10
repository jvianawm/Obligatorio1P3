using LogicaNegocio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    internal class RepositorioUsuario : IRepositorioUsuario

    {
        public PlataformaContext Context { get; set; }

        public RepositorioUsuario(PlataformaContext context)
        {
            Context = context;
        }



        public void Add(Usuario obj)
        {
           if (obj != null)
            {
                obj.Validar();
                obj.ValidarFecha();

                Context.UsuarioAutorizado.Add(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un usuario");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Context.UsuarioAutorizado.ToList();
        }

        public Usuario FindById(int id)
        {
            return Context.UsuarioAutorizado.Find(id);
        }

        public void Remove(Usuario obj)
        {
            if(obj != null)
            {
                Context.Remove(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un usuario");
            }
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
