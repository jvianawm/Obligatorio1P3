
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
    public class ModificarPais : IModificarPais
    {
        public IRepositorioPais Repo { get; set; }  

        public ModificarPais (IRepositorioPais repo)
        {
            Repo = repo;
        }
        public void Modificar(Pais pais)
        {
            Repo.Update(pais);
        }
    }
}
