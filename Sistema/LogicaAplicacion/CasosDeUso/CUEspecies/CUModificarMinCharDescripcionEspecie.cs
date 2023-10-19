using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Parametros;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    internal class CUModificarMinCharDescripcionEspecie : IModificarMinDescripcionEspecie
    {
        public  IRepositorioParametros Repo { get; set; }

        public CUModificarMinCharDescripcionEspecie(IRepositorioParametros repo)
        {
            Repo = repo;
        }
        public void Modificar(int valorNuevo)
        {
            Parametro par = Repo.BuscarParametroPorNombre("MinCharNom");
            par.Valor = valorNuevo.ToString();
            Repo.Update(par);   

            NombreCientifico.MinCharNom = valorNuevo;            
        }
    }
}
