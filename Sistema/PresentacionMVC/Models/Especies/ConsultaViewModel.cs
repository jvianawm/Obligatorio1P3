﻿using LogicaNegocio.Dominio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class ConsultaEspecieViewModel
    {
        // Ecosistemas
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        //public int[] IdsEcosistemasSeleccionados { get; set; }

        public IEnumerable<Especie> Especies { get; set; }
        public int IdEspecieSeleccionada { get; set; }     

        public string RutaDirectorioImagenesEspecies { get; set; }
        public string RutaDirectorioImagenesEcosistemas { get; set; }

    }
}
