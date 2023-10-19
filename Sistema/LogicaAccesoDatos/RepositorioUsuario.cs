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
        public static string? NombreUsuario { get; set; }

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

            NombreUsuario = usuario.Alias;

            return login;
        }
                
        public void Add(Usuario usuario)
        {                        
            if (usuario != null)
            {
                usuario.FechaIngreso = DateTime.Now;               
                usuario.PasswordEncriptado = Usuario.EncriptarPassword(usuario.Password);

                usuario.Validar();
                Usuario.ValidarPassword(usuario.Password);

                bool yaExiste = Context.Usuario.Where(
                                   u => u.Alias.Trim().ToLower() == usuario.Alias.Trim().ToLower()
                               ).Any();

                if( yaExiste) {
                   throw new UsuarioException("Ya existe un usuario con ese alias");
                }                

                Context.Usuario.Add(usuario);
                Context.SaveChanges();

                RepositorioLog.Registrar(usuario.Id, "Usuario:Add", Context);
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un usuario");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }        
    }
}
