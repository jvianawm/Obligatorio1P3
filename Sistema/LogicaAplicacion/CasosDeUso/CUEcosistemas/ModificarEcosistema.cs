﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ModificarEcosistema : IModificarEcosistema
    {
        public IRepositorioEcosistema Repo { get; set; }

        public ModificarEcosistema (IRepositorioEcosistema repo)
        {
            Repo= repo;
        }

        public void Modificar(Ecosistema ecosistema)
        {
            Repo.Update(ecosistema);
        }
    }
}
