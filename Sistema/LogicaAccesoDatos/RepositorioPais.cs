using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioPais : IRepositorioPais
    {
        public PlataformaContext Context { get; set; }

        public RepositorioPais(PlataformaContext context)
        {
            Context = context;
        }

        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
            return Context.Pais;
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindByIds(List<int> ids)
        {
            return Context.Pais.Where(p => ids.Contains(p.Id));
        }

        public void Remove(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
