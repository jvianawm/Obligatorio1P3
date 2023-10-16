using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
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
    public class CUAsignarEspecieEcosistema : IAsignarEspecieEcosistema
    {
        public IRepositorioEcosistema Repo { get; set; }

        public CUAsignarEspecieEcosistema(IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public void AsignarEspecie(Ecosistema ecosistema)
        {
            Repo.AsignarEspecie(ecosistema);
        }
    }
}
