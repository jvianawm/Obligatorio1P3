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
    public class CUModificarMaxCharDescripcionEspecie : IModificarMaxCharDescripcionEspecie
    {
        public  IRepositorioParametros Repo { get; set; }

        public CUModificarMaxCharDescripcionEspecie(IRepositorioParametros repo)
        {
            Repo = repo;
        }
        public void Modificar(int valorNuevo)
        {
            Parametro par = Repo.BuscarParametroPorNombre("MaxCharDesc");
            par.Valor = valorNuevo.ToString();

            var minimo = Repo.BuscarValorPorNombre("MinCharDesc");

            if (valorNuevo < Int32.Parse(minimo))
            {
                throw new Exception("El valor máximo no puede ser menor que el mínimo");
            }

            Repo.Update(par);   

            NombreCientifico.MinCharNom = valorNuevo;            
        }
    }
}
