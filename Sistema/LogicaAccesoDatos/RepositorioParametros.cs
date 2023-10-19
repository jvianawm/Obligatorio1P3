using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioParametros : IRepositorioParametros
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioParametros(PlataformaContext ctx)
        {
            Contexto = ctx;
        }

        

        public Parametro BuscarParametroPorNombre(string nombre)
        {
            return Contexto.Parametros.Where(par => par.Nombre == nombre).SingleOrDefault();
        }

        public string BuscarValorPorNombre(string nombre)
        {
            var res = Contexto.Parametros
                        .Where(par => par.Nombre == nombre)
                        .Select(par => par.Valor)
                        .SingleOrDefault();

            return res;
        }




        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            throw new NotImplementedException();
        }


    }
}
