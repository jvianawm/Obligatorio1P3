
namespace ExcepcionesPropias
{
    public class EcosistemaException : Exception
    {
        public EcosistemaException() : base() { } 
        public EcosistemaException(string message) : base(message) { }
        public EcosistemaException(string message, Exception interna) : base(message, interna) { }
    }
}
