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
    public class CUListarEspecies: IListarEspecies
    {
        public IRepositorioEspecie Repo { get; set; }

        public CUListarEspecies (IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public IEnumerable<Especie> Listar()
        {
            return Repo.FindAll();
        }

        public IEnumerable<Especie> FindByIds(List<int> ids)
        {
            return Repo.FindByIds(ids);
        }
    }
}
