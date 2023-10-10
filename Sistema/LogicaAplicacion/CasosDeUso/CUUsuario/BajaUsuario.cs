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
    public class BajaUsuario: IBajaUsuario
    {
        public IRepositorioUsuario Repo { get;set; }
        public BajaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Eliminar(Usuario usuario)
        {
            Repo.Remove(usuario);   
        }
    }
}