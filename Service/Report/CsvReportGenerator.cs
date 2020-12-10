namespace solidInCsharp.Service.Report
{
    public class CsvReportGenerator: IReportGenerator
    {
		private string relatorio; 

		public void IniciarRelatorio() {
			relatorio = "";
		}
		
		public void IniciarHeaders() {

		}
		public void AdicionarHeader(string valor) {
			relatorio += valor + ";";
		}

		public void FinalizarHeaders() {
			relatorio = relatorio.Substring(0, relatorio.Length -1);
			relatorio += "\r\n";
		}
		public void IniciarLinha() {

		}

		public void AdicionarColuna(string valor) {
			relatorio += valor + ";";
		}
		
		public void FinalizarLinha() {
			relatorio = relatorio.Substring(0, relatorio.Length -1);
			relatorio += "\r\n";
		}
		public string FinalizarRelatorio() {
			return relatorio;
		}
    }
}