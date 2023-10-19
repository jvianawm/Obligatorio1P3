
namespace ExcepcionesPropias
{
    public class EspecieException : Exception
    {
        public EspecieException() : base() { } 
        public EspecieException(string message) : base(message) { }
        public EspecieException(string message, Exception interna) : base(message, interna) { }
    }
}
