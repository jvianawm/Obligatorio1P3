﻿using LogicaNegocio.Dominio;
using LogicaNegocio.Interfaces_de_Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
    {
        public IEnumerable<Ecosistema> FindByIds(List<int> ids);

        public void AsignarEspecie(Ecosistema ecosistema);
    }
}
