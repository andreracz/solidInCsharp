using Moq;
using solidInCsharp.Model;
using solidInCsharp.Repository;
using solidInCsharp.Service;
using Xunit;

namespace solidInCsharp.Tests
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<ICriptografiaService> _criptografiaServiceMock;
        private readonly Mock<IJWTService> _jwtServiceMock;
        private readonly IUsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _criptografiaServiceMock = new Mock<ICriptografiaService>();
            _jwtServiceMock = new Mock<IJWTService>();
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object, _criptografiaServiceMock.Object, _jwtServiceMock.Object);
        }

        [Fact]
        public void CriarUsuario_DeveChamarRepositorioParaSalvarUsuario()
        {
            // Arrange
            var email = "teste@teste.com";
            var nome = "Teste";
            var senha = "123";
            _criptografiaServiceMock.Setup(x => x.CriptografarSenha(It.IsAny<string>())).Returns("senhaCriptografada");

            // Act
            _usuarioService.CriarUsuario(email, nome, senha);

            // Assert
            _usuarioRepositoryMock.Verify(x => x.Add(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
