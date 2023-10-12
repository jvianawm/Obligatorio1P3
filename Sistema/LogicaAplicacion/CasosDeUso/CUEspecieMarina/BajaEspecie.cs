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
    public class BajaEspecie : IBajaEspecieMarina
    {
        public IRepositorioEspecieMarina Repo { get; set; }

        public BajaEspecie (IRepositorioEspecieMarina repo)
        {
            Repo = repo;
        }

        public void Eliminar(EspecieMarina especie)
        {
            Repo.Remove(especie);   
        }
    }
}
