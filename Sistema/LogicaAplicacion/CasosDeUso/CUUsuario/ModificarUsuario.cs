using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ModificarUsuario: IModificarUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public ModificarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Modificar(Usuario usuario)
        {
            Repo.Update(usuario);
        }
    }
}
