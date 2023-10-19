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
    public class DescripcionEspecie
    {
        public static int MaxCharDesc { get; set; }
        public static int MinCharDesc { get; set; }

        [Column("Descripcion")]
        public string Value { get; private set; }

        public DescripcionEspecie(string value)
        {
            Value = value;
            Validar();
        }

        private DescripcionEspecie()
        {      
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("Valor de descripcíon inválido");
            if (Value.Length > MaxCharDesc || Value.Length < MinCharDesc)
                throw new InvalidOperationException(
                    "La descripción debe tener entre " + MinCharDesc + " y " + MaxCharDesc + " caracteres"
                );
        }
    }
}
