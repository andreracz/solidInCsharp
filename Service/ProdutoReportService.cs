
using solidInCsharp.Service.Report;
using solidInCsharp.Repository;


namespace solidInCsharp.Service
{
    public class ProdutoReportService: IProdutoReportService
    {

		private IProdutoRepository repository;

        public ProdutoReportService(IProdutoRepository repository) {
			this.repository = repository;
		}

		public string GerarRelatorio(IReportGenerator generator) {
			var produtos = this.repository.ListAll();
			generator.IniciarRelatorio();
			generator.IniciarHeaders();
			generator.AdicionarHeader("ID");
			generator.AdicionarHeader("Nome");
			generator.AdicionarHeader("Preço");
			generator.FinalizarHeaders();
			foreach (var produto in produtos)
			{
				generator.IniciarLinha();
				generator.AdicionarHeader(produto.Id);
				generator.AdicionarHeader(produto.Nome);
				generator.AdicionarHeader(produto.Preco + "");
				generator.FinalizarLinha();
			}
			return generator.FinalizarRelatorio();
		}
		
    }
}