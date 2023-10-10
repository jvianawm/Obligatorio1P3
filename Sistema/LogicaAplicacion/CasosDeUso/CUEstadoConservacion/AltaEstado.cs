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
    public class AltaEstado : IAltaEstadoConservacion
    {
        public IRepositorioEstadoConservacion Repo { get; set; }

        public AltaEstado (IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

        public void Alta(EstadoConservacion estado)
        {
            Repo.Add(estado);
        }
    }
}
