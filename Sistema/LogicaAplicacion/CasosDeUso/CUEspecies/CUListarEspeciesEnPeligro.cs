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
    public class CUListarEspeciesEnPeligro : IListarEspeciesEnPeligro
    {
        public IRepositorioEspecie Repo { get; set; }

        public CUListarEspeciesEnPeligro(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public IEnumerable<Especie> Listar()
        {
            return Repo.FindEspeciesEnPeligro();
        }
    }
}
