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
    public class AltaPais: IAltaPais
    {
        public IRepositorioPais Repo { get; set; }  
        public AltaPais (IRepositorioPais repo)
        {
            Repo = repo;        }

        public void Alta(Pais pais)
        {
            Repo.Add(pais);
        }
    }
}
