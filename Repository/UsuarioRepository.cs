using Microsoft.EntityFrameworkCore;
using solidInCsharp.Model;

namespace solidInCsharp.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, UsuarioRepository>
    {
        public UsuarioRepository(DbContextOptions<UsuarioRepository> options)
			: base(options)
		{ }


    }
}