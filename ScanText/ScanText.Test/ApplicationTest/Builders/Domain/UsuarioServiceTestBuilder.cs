using Moq;
using ScanText.Security.Authentication.Interfaces;

namespace ScanText.Test.ApplicationTest.Builders.Domain
{
    public class UsuarioServiceTestBuilder : BaseTestBuilder<Mock<IUsuarioService>>
    {
        public UsuarioServiceTestBuilder()
        {
            Model = new Mock<IUsuarioService>();
        }
    }
}
