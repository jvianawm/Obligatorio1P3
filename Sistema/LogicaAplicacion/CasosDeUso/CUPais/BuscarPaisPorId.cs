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
    public class BuscarPaisPorId : IBuscarPaisPorId
    {
        public IRepositorioPais Repo { get; set; }  

        public BuscarPaisPorId (IRepositorioPais repo)
        {
            Repo = repo;    
        }

        public Pais Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
