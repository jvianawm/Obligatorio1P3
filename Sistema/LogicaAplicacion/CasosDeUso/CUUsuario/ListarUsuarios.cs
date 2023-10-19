using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ListarUsuarios : IListarUsuarios
    {
        public IRepositorioUsuario Repo { get; set; }

        public ListarUsuarios (IRepositorioUsuario repo)
        {
            Repo = repo;    
        }

        public IEnumerable<Usuario> Listar()
        {
            return Repo.FindAll();
        }
    }
}
