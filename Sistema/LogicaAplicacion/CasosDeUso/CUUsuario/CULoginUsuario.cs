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
    public class CULoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CULoginUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public bool Login(Usuario usuario)
        {            
            return Repo.Login(usuario);
        }
    }
}
