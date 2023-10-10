using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExepcionesPropias
{
    public class AmenazaExeption: Exception
    {
        public AmenazaExeption() : base() { }

        public AmenazaExeption(string message) : base(message) { }

        public AmenazaExeption(string message, Exception interna): base(message, interna) { }
        
    }
}
