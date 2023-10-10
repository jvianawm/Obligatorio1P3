using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IBuscarEspeciePorId
    {
        EspecieMarina Buscar(int id);

    }
}
