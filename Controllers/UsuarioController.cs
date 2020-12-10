using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using solidInCsharp.Service;
using solidInCsharp.Model;

namespace solidInCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase {
    

        private readonly ILogger<UsuarioController> _logger;
		private readonly IUsuarioService usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
			this.usuarioService = usuarioService;
        }

        [HttpPost]
		[Route("login")]
		public ActionResult<dynamic> Login([FromBody]Usuario model)
		{
			// Recupera o usuário
			var token = usuarioService.Login(model.Email, model.Senha);
			
			// Retorna os dados
			return new
			{
				token = token
			};
		}

		[HttpPost]
		public ActionResult<dynamic> CreateUser([FromBody]Usuario model)
		{
			// Recupera o usuário
			usuarioService.CriarUsuario(model.Email, model.Nome, model.Senha);
			
			// Retorna os dados
			return new
			{
				
			};
		}
       
    }
}
