using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesPropias;

namespace LogicaAccesoDatos
{
    public class RepositorioAmenaza : IRepositorioAmenaza
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioAmenaza (PlataformaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Amenaza obj)
        {
          if(obj != null)
            {
                obj.Validar();
                try
                {
                    Contexto.Amenazas.Add(obj);
                    Contexto.SaveChanges();
                }
                catch(Exception ex) 
                {
                    throw new InvalidOperationException("No se provee informacion de la Amenaza para el alta", ex);
                }     
            }
        }

        public IEnumerable<Amenaza> FindAll()
        {
            return Contexto.Amenazas.ToList();
        }

        public Amenaza FindById(int id)
        {         
              return  Contexto.Amenazas.Find(id);                    
        }

        public IEnumerable<Amenaza> FindByIds(List<int> ids)
        {
            return Contexto.Amenazas.Where(p => ids.Contains(p.Id));
        }

        public void Remove(Amenaza obj)
        {
            if(obj != null)
            {
                obj.Validar();
                try
                {
                    Contexto.Remove(obj);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)

                {
                    throw new InvalidOperationException("No se provee informacion de la amenaza para la baja ");
                }
                    
            }
        }

        public void Update(Amenaza obj)
        {
            if (obj != null)
            {
                obj.Validar();
                try
                {
                    Contexto.Update(obj);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)

                {
                    throw new AmenazaExeption("No se pudo modificar la amenaza", ex);
                }
            }
        }

    }
}
