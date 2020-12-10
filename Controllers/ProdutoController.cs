using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using solidInCsharp.Service;
using solidInCsharp.Service.Report;
using solidInCsharp.Model;
using Microsoft.AspNetCore.Authorization;

namespace solidInCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase {
    

        private readonly ILogger<ProdutoController> _logger;
		private readonly IProdutoReportService produtoReportService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoReportService produtoReportService)
        {
            _logger = logger;
			this.produtoReportService = produtoReportService;
        }


		[HttpGet]
		[Authorize]
		public ActionResult<string> RelatorioProdutos([FromQuery]TipoRelatorio tipoRelatorio)
		{
			// Retorna os dados 
			return produtoReportService.GerarRelatorio(ReportGeneratorFactory.ObterGerador(tipoRelatorio));
		}
       
    }
}
