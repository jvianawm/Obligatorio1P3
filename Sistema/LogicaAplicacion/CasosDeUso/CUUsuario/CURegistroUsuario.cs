using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CURegistroUsuario : IRegistroUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CURegistroUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Registrar(Usuario usuario)
        {             
            Repo.Add(usuario);
        }
    }
}
