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
    public class BajaPais : IBajaPais
    {
        public IRepositorioPais Repo { get; set; }
        public BajaPais (IRepositorioPais repo)
        {
            Repo = repo;    
        }

        public void Baja(Pais pais)
        {
            Repo.Remove(pais); 
        }
    }
}
