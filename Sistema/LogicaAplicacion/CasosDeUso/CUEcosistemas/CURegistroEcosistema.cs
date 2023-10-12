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
    public class CURegistroEcosistema : IRegistroEcosistema
    {
        public IRepositorioEcosistema Repo { get; set; }

        public CURegistroEcosistema(IRepositorioEcosistema repo)
        {
            Repo = repo;
        }

        public void Registrar(Ecosistema ecosistema)
        {
            Repo.Add(ecosistema);
        }
    }
}
