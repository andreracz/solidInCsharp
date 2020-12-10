using System.Collections.Generic;
using solidInCsharp.Model;

namespace solidInCsharp.Repository
{
    public interface IUsuarioRepository: IReadWriteRepository<Usuario>
    {
		public Usuario ObterUsuario(string Email);
    }
}