using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            return Context.Especies.Find(id);
        }

        public IEnumerable<Especie> FindByIds(List<int> ids)
        {
            return Context.Especies.Where(p => ids.Contains(p.Id));
        }

        // Especies en peligro de extinción
        // (las que su estado de conservación sea menor que 60,
        // también las que sufran más de 3 amenazas
        // o también si habitan un ecosistema que sufra más de 3 amenazas siempre que ese ecosistema tenga un grado de conservación menor que 60).
        public IEnumerable<Especie> FindEspeciesEnPeligro()
        {
            return Context.Especies
                .Include(ec => ec.Ecosistemas)
                .Where(
                    es => es.EstadoConservacion.Estado < 60
                 || es.Amenazas.Count() > 3
                 || es.Ecosistemas.Any(ec => ec.Amenazas.Count() > 3 && ec.EstadoConservacion.Estado < 60)
                ).ToList();
        }

        public IEnumerable<Especie> FindByRangoPeso(decimal minimo, decimal maximo)
        {
            return Context.Especies
                .Include(ec => ec.Ecosistemas)
                .Where(e => e.PesoMinimo >= minimo && e.PesoMaximo <= maximo);
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
