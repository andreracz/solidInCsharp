
using solidInCsharp.Service.Report;
using solidInCsharp.Repository;


namespace solidInCsharp.Service
{
    public interface IProdutoReportService
    {

		
		public string GerarRelatorio(IReportGenerator generator);
	}
}