using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.Interfaces_de_Repositorio;
using LogicaNegocio.InterfacesdeRepositorio;
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
            return Repo.FindById(id);
        }
    }
}
