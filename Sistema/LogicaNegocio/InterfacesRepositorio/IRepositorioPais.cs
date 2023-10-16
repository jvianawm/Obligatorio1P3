﻿using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces_de_Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        public IEnumerable<Pais> FindByIds(List<int> ids);
    }
}
