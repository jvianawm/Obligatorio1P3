using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEcosistema : IRepositorioEcosistema
    {
        public PlataformaContext Context { get; set; }

        public RepositorioEcosistema(PlataformaContext context)
        {
            Context = context;
        }

        public void Add(Ecosistema ecosistema)
        {
            if (ecosistema != null)
            {
                ecosistema.Validar();
                
                bool yaExiste = Context.Ecosistemas.Where(
                                   e => e.Nombre.Trim().ToLower() == ecosistema.Nombre.Trim().ToLower()
                                ).Any();

                if (yaExiste)
                {
                    throw new UsuarioException("Ya existe un ecosistema con ese nombre");
                }                

                Context.Ecosistemas.Add(ecosistema);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un ecosistema");
            }
        }

        public void AsignarEspecie(Ecosistema ecosistema)
        {
            if (ecosistema != null)
            {
                if(ecosistema.Id == default)
                {
                    throw new EcosistemaException("No se recibió el identificador del ecosistema");
                }

                if (ecosistema.Especies == null 
                 || ecosistema.Especies.Count() != 1 
                 || ecosistema.Especies.First().Id == default)
                {
                    throw new EcosistemaException("No se recibió el identificador de la especie");
                }

                Especie? especie = Context.Especies
                    .Include(e => e.Ecosistemas)
                    .Include(e => e.Amenazas)
                    .Include(e => e.EstadoConservacion)
                    .Where(e => e.Id == ecosistema.Especies.First().Id)
                    .FirstOrDefault();

                if (especie == null)
                {
                    throw new UsuarioException("No se encontró la especie");
                }

                Ecosistema? ecosistemaEnbase = Context.Ecosistemas
                    .Include(e => e.Especies)
                    .Include(e => e.Amenazas)
                    .Include(e => e.EspeciesPosibles)
                    .Include(e => e.EstadoConservacion)
                    .Where(e => e.Id == ecosistema.Id)
                    .FirstOrDefault();

                if (ecosistemaEnbase == null)
                {
                    throw new UsuarioException("No se encontró el ecosistema");
                }

                ecosistema = ecosistemaEnbase;

                if(ecosistema.Especies != null)
                {
                    // Cada especie puede ser asociada una única vez a un ecosistema
                    bool yaExiste = Context.Ecosistemas
                            .Where(
                                ec => ec.Id == ecosistema.Id
                                   && ec.Especies.Contains(especie)
                             ).Any();

                    if (yaExiste)
                    {
                        throw new UsuarioException("Ya existe la especie en el ecosistema");
                    }
                }

                // Ese ecosistema debe ser alguno de los apropiados para la supervivencia de la especie.
                bool esApropiado = Context.Ecosistemas                        
                        .Where(ec => ec.Id == ecosistema.Id         // Sea el ecosistema (Id)
                                 &&  ec.EspeciesPosibles            // Y ese ecositema tenga como especie posible...
                                    .Where(
                                        x => x.Id == especie.Id     // ...la que queremos agregar
                                    ).Any()
                         ).Any();

                // Una especie no puede ser asociada a un ecosistema que sufra las mismas amenazas que sufre esa especie pues no sobrevive
                if(especie.Amenazas.Any() && ecosistema.Amenazas.Any())
                {
                    // ToDo: Mejorar
                    bool comparteAmenazas = ecosistema.Amenazas.Intersect(especie.Amenazas).Any();                    

                    if (comparteAmenazas)
                    {
                        throw new UsuarioException("No se puede agregar una especie porque comparte amenazas con el ecosistema");
                    }
                }

                // Asimismo, se verificará que el estado de conservación del ecosistema no sea peor que el de la especie que se le está asociando.
                var estadoEcosistemaPeorQueEspecie = Context.Ecosistemas
                        .Where(
                            ec => ec.Id == ecosistema.Id
                               && ec.EstadoConservacion.Estado > especie.EstadoConservacion.Estado
                        ).Any();

                if (estadoEcosistemaPeorQueEspecie)
                {
                    throw new UsuarioException("El estado de conservación del ecosistema es peor que el de la especie");
                }

                ecosistema.Especies.Add(especie);

                ecosistema.Validar();

                Context.Ecosistemas.Update(ecosistemaEnbase);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se proporciono un ecosistema");
            }
        }

        public IEnumerable<Ecosistema> FindAll()
        {
            return Context.Ecosistemas;
        }

        public Ecosistema FindById(int id)
        {
            return Context.Ecosistemas
                    .Include(e => e.Amenazas)
                    .Include(e => e.Especies)
                    .Include(e => e.EspeciesPosibles)
                    .Include(e => e.EstadoConservacion)
                    .Where(e => e.Id == id)
                    .First();
        }

        public IEnumerable<Ecosistema> FindByIds(List<int> ids)
        {
            return Context.Ecosistemas.Where(p => ids.Contains(p.Id));
        }

        // Dada una especie, todos los ecosistemas en los que no puede habitar.
        public IEnumerable<Ecosistema> ObtenerEcosistemasEspecieNoPuedeHabitar(int idEspecie)
        {
            return Context.Ecosistemas
                    .Include(es => es.EstadoConservacion)
                    .Where(a => Context.Especies
                                .Where(i => i.Id == idEspecie)
                                .Any(b => b.Amenazas
                                            .Any(z => a.Amenazas
                                                        .Any(x => x.Id == z.Id)
                                             )
                                 )
                    );
        }

        public void Remove(Ecosistema obj)
        {
            if(obj != null)
            {
                Ecosistema? ecosistema = Context.Ecosistemas
                    .Include(e => e.Especies)
                    .Include(e => e.EspeciesPosibles)
                    .Where(e => e.Id == obj.Id).FirstOrDefault();

                if (ecosistema == null) 
                {
                    throw new EcosistemaException("No se encontró el ecosistema");
                }

                if (ecosistema.Especies.Count() > 0 || ecosistema.EspeciesPosibles.Count() > 0)
                {
                    throw new EcosistemaException("No se puede eliminar debido a que el ecosistema contiene especies asociadas");
                }

                Context.Remove(ecosistema);
                Context.SaveChanges();                
            }
            else 
            {
                throw new EcosistemaException("No se proporcionó un ecosistema");
            }
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ecosistema> FindByEcosistemaId(int id)
        {
            return Context.Ecosistemas.Where(ec => ec.Especies.Any(es => es.Id == id));
        }
    }
}
