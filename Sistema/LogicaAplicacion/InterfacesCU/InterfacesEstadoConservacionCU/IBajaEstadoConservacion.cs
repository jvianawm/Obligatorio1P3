using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IBajaEstadoConservacion
    {
        void Eliminar(EstadoConservacion estado);
    }
}
