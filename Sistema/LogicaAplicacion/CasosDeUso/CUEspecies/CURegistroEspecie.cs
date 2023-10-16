using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CURegistroEspecie : IRegistroEspecie
    {
        public IRepositorioEspecie Repo { get; set; }

        public CURegistroEspecie(IRepositorioEspecie repo)
        {
            Repo = repo;
        }

        public void Registrar(Especie especie)
        {
            Repo.Add(especie);
        }
    }
}
