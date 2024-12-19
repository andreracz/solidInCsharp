using System;
using Xunit;
using solidInCsharp.Service;

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
        public void Encrypt_ShouldEncryptPlainText()
        {
            // Arrange
            string plainText = "Hello, World!";
            string key = "0123456789abcdef"; // 16 bytes key

            // Act
            string encryptedText = _criptografiaService.Encrypt(plainText, key);

            // Assert
            Assert.NotNull(encryptedText);
            Assert.NotEqual(plainText, encryptedText);
        }

        [Fact]
        public void Decrypt_ShouldDecryptCipherText()
        {
            // Arrange
            string plainText = "Hello, World!";
            string key = "0123456789abcdef"; // 16 bytes key
            string encryptedText = _criptografiaService.Encrypt(plainText, key);

            // Act
            string decryptedText = _criptografiaService.Decrypt(encryptedText, key);

            // Assert
            Assert.NotNull(decryptedText);
            Assert.Equal(plainText, decryptedText);
        }
    }
}
