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
    public class BuscarEstadoPorId : IBuscarEstadoConservacionPorId
    {
        public IRepositorioEstadoConservacion Repo { get; set; }    

        public BuscarEstadoPorId(IRepositorioEstadoConservacion repo)
        {
            Repo = repo;
        }

            public EstadoConservacion Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}