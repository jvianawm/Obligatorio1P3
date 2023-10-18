using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class AltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecie Repo {  get; set; }
        public AltaEspecie(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public void Alta(Especie especie)
        {
            Repo.Add(especie);
        }
    }
}
