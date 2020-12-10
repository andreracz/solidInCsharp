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
    public class UsuarioService: IUsuarioService
    {
		private IUsuarioRepository repository;

		private ICriptografiaService criptografiaService;

		private IJWTService jWTService;

        public UsuarioService(IUsuarioRepository repository, ICriptografiaService criptografia, IJWTService jwt){ 
			this.repository = repository;
			this.criptografiaService = criptografia;
			this.jWTService = jwt;
		}

		public void CriarUsuario(string Email, string Name, string Password) {
			var user = this.repository.ObterUsuario(Email);
			if (user != null) {
				throw new Exception("Erro, usuário já existe");
			}
			user = new Usuario() { Email = Email, Nome = Name, Senha = criptografiaService.CriptografarSenha(Password)};
			this.repository.Add(user);
		}

		public string Login(string Email,  string Password) {
			var user = this.repository.ObterUsuario(Email);
			if (user == null || !criptografiaService.ValidarSenha(user.Senha, Password)) {
				throw new Exception("Erro, usuário ou senha incorreto");
			}
			return jWTService.GerarToken(user);
		}


    }
}