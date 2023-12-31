﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUBuscarEspeciePorId: IBuscarEspeciePorId
    {
        public IRepositorioEspecie Repo {  get; set; }    

        public CUBuscarEspeciePorId(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public Especie Buscar(int id)
        {
           return Repo.FindById(id);
        }
    }
}
