
namespace ExcepcionesPropias
{
    public class PaisException : Exception
    {
        public PaisException() : base() { }
        public PaisException(string message) : base(message) { }
        public PaisException(string message, Exception interna) : base(message, interna) { }
    }
}
