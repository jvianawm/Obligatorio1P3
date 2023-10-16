using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public PlataformaContext Context { get; set; }

        public RepositorioUsuario(PlataformaContext context)
        {
            Context = context;
        }

        public bool Login(Usuario usuario)
        {
            usuario.PasswordEncriptado = Usuario.EncriptarPassword(usuario.Password);

            bool login = Context.Usuario.Where(
                u => u.Alias    == usuario.Alias 
                  && u.PasswordEncriptado == usuario.PasswordEncriptado
            ).Any();

            if(!login)
            {
                throw new UsuarioException("No se encontró un usuario con las credenciales proporcionadas");
            }

            return login;
        }
                
        public void Add(Usuario usuario)
        {                        
            if (usuario != null)
            {
                usuario.FechaIngreso = DateTime.Now;               
                usuario.PasswordEncriptado = Usuario.EncriptarPassword(usuario.Password);

                usuario.Validar();
                usuario.ValidarFecha();

                bool yaExiste = Context.Usuario.Where(
                                   u => u.Alias.Trim().ToLower() == usuario.Alias.Trim().ToLower()
                               ).Any();

                if( yaExiste) {
                   throw new UsuarioException("Ya existe un usuario con ese alias");
                }                

                Context.Usuario.Add(usuario);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un usuario");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
            //return Context.Usuario.ToList();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
            //return Context.Usuario.Find(id);
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
            /*
            if (obj != null)
            {
                Context.Remove(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un usuario");
            }
            */
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
