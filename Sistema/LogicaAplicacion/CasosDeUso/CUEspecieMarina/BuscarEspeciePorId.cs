using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class BuscarEspeciePorId: IBuscarEspeciePorId
    {
        public IRepositorioEspecieMarina Repo {  get; set; }    

        public BuscarEspeciePorId(IRepositorioEspecieMarina repo)
        {
            Repo = repo;
        }

        public EspecieMarina Buscar(int id)
        {
           return Repo.FindById(id);
        }
    }
}
