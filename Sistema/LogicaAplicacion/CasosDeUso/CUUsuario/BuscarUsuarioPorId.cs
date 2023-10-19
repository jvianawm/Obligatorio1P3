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
    public class BuscarUsuarioPorId: IBuscarUsuarioPorId
    {
        public IRepositorioUsuario Repo { get; set; } 
        public BuscarUsuarioPorId(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public Usuario Buscar(int id)
        {
            throw new NotImplementedException();
            //return Repo.FindById(id);
        }
    }
}
