using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEspecie : IRepositorioEspecie
    {
        public PlataformaContext Context { get; set; }

        public RepositorioEspecie(PlataformaContext context)
        {
            Context = context;
        }

        public void Add(Especie especie)
        {
            if (especie != null)
            {
                especie.Validar();

                bool yaExiste = Context.Especies.Where(
                                   e => e.NombreCientifico.Trim().ToLower() == especie.NombreCientifico.Trim().ToLower()
                                ).Any();

                if (yaExiste)
                {
                    throw new UsuarioException("Ya existe una especie con ese nombre");
                }

                Context.Especies.Add(especie);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono una especie");
            }
        }

        public IEnumerable<Especie> FindAll()
        {
            return Context.Especies;
        }

        public Especie FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Especie> FindByIds(List<int> ids)
        {
            return Context.Especies.Where(p => ids.Contains(p.Id));
        }

        public void Remove(Especie obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Especie obj)
        {
            throw new NotImplementedException();
        }
    }
}
