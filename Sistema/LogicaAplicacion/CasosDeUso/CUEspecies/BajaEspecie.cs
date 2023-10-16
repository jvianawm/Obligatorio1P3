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
    public class BajaEspecie : IBajaEspecieMarina
    {
        public IRepositorioEspecie Repo { get; set; }

        public BajaEspecie (IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public void Eliminar(Especie especie)
        {
            Repo.Remove(especie);   
        }
    }
}
