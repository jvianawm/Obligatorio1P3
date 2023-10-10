﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces_de_Repositorio
{
    public interface IRepositorio <T>
    {
        void Add(T obj);

        void Remove(T obj);

        void Update(T obj);

        IEnumerable<T> FindAll();

        T FindById(int id);
    }
}
