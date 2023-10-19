using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Parametros;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUModificarMinCharDescripcionEspecie : IModificarMinCharDescripcionEspecie
    {
        public  IRepositorioParametros Repo { get; set; }

        public CUModificarMinCharDescripcionEspecie(IRepositorioParametros repo)
        {
            Repo = repo;
        }
        public void Modificar(int valorNuevo)
        {
            Parametro par = Repo.BuscarParametroPorNombre("MinCharDesc");
            par.Valor = valorNuevo.ToString();

            var maximo = Repo.BuscarValorPorNombre("MaxCharDesc");

            if(valorNuevo > Int32.Parse(maximo))
            {
                throw new Exception("El valor mínimo no puede superar al máximo");
            }

            Repo.Update(par);   

            NombreCientifico.MinCharNom = valorNuevo;            
        }
    }
}
