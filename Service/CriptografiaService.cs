using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Security.Cryptography;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using solidInCsharp.Model;
using solidInCsharp.Repository;


namespace solidInCsharp.Service
{
    public class CriptografiaService
    {

		public bool ValidarSenha(string senhaCripto, string senhaDigitada) {
			byte[] hashBytes = Convert.FromBase64String(senhaCripto);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			var pbkdf2 = new Rfc2898DeriveBytes(senhaDigitada, salt, 100000);
			byte[] hash = pbkdf2.GetBytes(20);
			for (int i=0; i < 20; i++) {
				if (hashBytes[i+16] != hash[i]) {
					return false;
				}
			}
			return true;
		}

		public string CriptografarSenha(string senha) {
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
			var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 100000);
			byte[] hash = pbkdf2.GetBytes(20);
			byte[] hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);
			return Convert.ToBase64String(hashBytes);
		}

    }
}