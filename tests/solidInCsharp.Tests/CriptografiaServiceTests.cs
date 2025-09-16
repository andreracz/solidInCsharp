using solidInCsharp.Service;
using Xunit;

namespace solidInCsharp.Tests
{
    public class CriptografiaServiceTests
    {
        private readonly ICriptografiaService _criptografiaService;

        public CriptografiaServiceTests()
        {
            _criptografiaService = new CriptografiaService();
        }

        [Fact]
        public void CriptografarSenha_DeveRetornarUmHashValido()
        {
            // Arrange
            var senha = "minhaSenhaSuperSecreta";

            // Act
            var hash = _criptografiaService.CriptografarSenha(senha);

            // Assert
            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
        }

        [Fact]
        public void ValidarSenha_DeveRetornarVerdadeiroParaSenhaCorreta()
        {
            // Arrange
            var senha = "minhaSenhaSuperSecreta";
            var hash = _criptografiaService.CriptografarSenha(senha);

            // Act
            var resultado = _criptografiaService.ValidarSenha(hash, senha);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void ValidarSenha_DeveRetornarFalsoParaSenhaIncorreta()
        {
            // Arrange
            var senhaCorreta = "minhaSenhaSuperSecreta";
            var senhaIncorreta = "senhaIncorreta";
            var hash = _criptografiaService.CriptografarSenha(senhaCorreta);

            // Act
            var resultado = _criptografiaService.ValidarSenha(hash, senhaIncorreta);

            // Assert
            Assert.False(resultado);
        }
    }
}
