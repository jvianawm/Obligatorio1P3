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
    public class ModificarEspecie : IModificarEspecie
    {
        public IRepositorioEspecie Repo { get; set; }

        public ModificarEspecie(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

            public void Modificar(Especie especie)
        {
            Repo.Update(especie);
        }
    }
}
