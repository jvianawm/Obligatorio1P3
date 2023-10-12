
namespace ExcepcionesPropias
{
    public class AmenazaExeption: Exception
    {
        public AmenazaExeption() : base() { }
        public AmenazaExeption(string message) : base(message) { }
        public AmenazaExeption(string message, Exception interna): base(message, interna) { }
        
    }
}
