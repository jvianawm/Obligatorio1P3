using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class RepositorioLog
    {
        public static void Registrar(int idEntidad, string tipoEntidad, PlataformaContext context)
        {
            Log log = new Log()
            {
                IdEntidad     = idEntidad,
                TipoEntidad   = tipoEntidad,
                NombreUsuario = RepositorioUsuario.NombreUsuario,
                FechaHora     = DateTime.Now
            };

            context.Log.Add(log);
            context.SaveChanges();
        }
    }
}
