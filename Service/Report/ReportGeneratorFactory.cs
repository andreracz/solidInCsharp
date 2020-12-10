namespace solidInCsharp.Service.Report
{
    public class ReportGeneratorFactory
    {
		public static IReportGenerator ObterGerador(TipoRelatorio tiporelatorio) {
			switch(tiporelatorio) {
				case TipoRelatorio.CSV:
					return new CsvReportGenerator();
				case TipoRelatorio.HTML:
				default:
					return new HtmlReportGenerator();
			}
		}
	}
}