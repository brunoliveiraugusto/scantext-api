namespace ScanText.Api.Configuration
{
    internal static class AuthorizationService
    {
        internal const string Administrador = "administrador";
        internal const string UsuarioComum = "usuarioComum";
        internal const string Todos = Administrador + "," + UsuarioComum;
    }
}
