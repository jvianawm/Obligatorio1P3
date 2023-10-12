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
    public class AltaEspecie : IAltaEspecieMarina
    {
        public IRepositorioEspecieMarina Repo {  get; set; }
        public AltaEspecie(IRepositorioEspecieMarina repo)
        {
            Repo = repo;
        }

        public void Alta(EspecieMarina especie)
        {
            Repo.Add(especie);
        }
    }
}
