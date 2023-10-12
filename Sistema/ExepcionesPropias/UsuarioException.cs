
namespace ExcepcionesPropias
{
    public class UsuarioException : Exception
    {
        public UsuarioException(): base() { }
        public UsuarioException(string message) : base(message) { }
        public UsuarioException(string message, Exception interna): base(message, interna) { }

    }
}
