﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesdeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class ModificarEspecie : IModificarEspecie
    {
        public IRepositorioEspecieMarina Repo { get; set; }

        public ModificarEspecie(IRepositorioEspecieMarina repo)
        {
            Repo = repo;
        }

            public void Modificar(EspecieMarina especie)
        {
            Repo.Update(especie);
        }
    }
}
