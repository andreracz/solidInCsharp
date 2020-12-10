
using System;

using solidInCsharp.Model;
using solidInCsharp.Repository;


namespace solidInCsharp.Service
{
    public interface IUsuarioService
    {


		public void CriarUsuario(string Email, string Name, string Password);

		public string Login(string Email,  string Password);


    }
}