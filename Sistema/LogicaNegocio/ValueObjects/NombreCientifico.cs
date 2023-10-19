using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Index(nameof(Value), IsUnique = true)]
    public class NombreCientifico
    {
        public static int MaxCharNom { get; set; }
        public static int MinCharNom { get; set; }

        [Column("NombreCientifico")]
        public string Value { get; private set; }

        public NombreCientifico(string value)
        {
            Value = value;
            Validar();
        }

        private NombreCientifico()
        {      
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("Valor de nombre inválido");
            if (Value.Length > MaxCharNom || Value.Length < MinCharNom)
                throw new InvalidOperationException(
                    "El nombre debe tener entre " + MinCharNom + " y " + MaxCharNom + " caracteres"
                );
        }
    }
}
