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
    public class UsuarioService
    {
		private IUsuarioRepository repository;

        public UsuarioService(IUsuarioRepository repository){ 
			this.repository = repository;
		}

		public void CriarUsuario(string Email, string Name, string Password) {
			var user = this.repository.ObterUsuario(Email);
			if (user != null) {
				throw new Exception("Erro, usuário já existe");
			}
			user = new Usuario() { Email = Email, Nome = Name, Senha = new CriptografiaService().CriptografarSenha(Password)};
			this.repository.Add(user);
		}

		public string Login(string Email,  string Password) {
			var user = this.repository.ObterUsuario(Email);
			if (user == null || !new CriptografiaService().ValidarSenha(user.Senha, Password)) {
				throw new Exception("Erro, usuário ou senha incorreto");
			}
			return new JWTService().GerarToken(user);
		}


    }
}