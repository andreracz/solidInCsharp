using System;

using System.Linq;
using solidInCsharp.Repository;


namespace solidInCsharp.Service
{
    public class ProdutoReportService
    {

		private ProdutoRepository repository;

        public ProdutoReportService(ProdutoRepository repository) {
			this.repository = repository;
		}

		public string GerarRelatorio(TipoRelatorio tipo) {
			var produtos = this.repository.ListAll();
			if (tipo == TipoRelatorio.CSV) {
				string relatorio = "ID;Nome;Preço\r\n";
				foreach (var produto in produtos)
				{
					relatorio += produto.Id + ";" + produto.Nome + ";" + produto.Preco + "\r\n";
				}
				return relatorio;
			} else if (tipo == TipoRelatorio.HTML) {
				string relatorio = "<html><body><table>\r\n<th><td>ID</td><td>Nome</td><td>Preço</td></th>\r\n";
				foreach (var produto in produtos)
				{
					relatorio += "<tr><td>" + produto.Id + "</td><td>" + produto.Nome + "</td><td>" + produto.Preco + "</td></tr>\r\n";
				}
				relatorio += "</table></body><html>";
				return relatorio;
			} 
			throw new Exception("tipo de relatorio invalido");
		}
    }
}