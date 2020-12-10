namespace solidInCsharp.Service.Report
{
    public class HtmlReportGenerator: IReportGenerator
    {
		private string relatorio;

		public void IniciarRelatorio() {
			relatorio = "<html><body><table>\r\n";
		}
		
		public void IniciarHeaders() {
			relatorio += "\t<th>\r\n";
		}
		public void AdicionarHeader(string valor) {
			relatorio += "\t\t<td>" + valor + "</td>\r\n";
		}

		public void FinalizarHeaders() {
			relatorio += "\t</th>\r\n";
		}
		public void IniciarLinha() {
			relatorio += "\t<tr>\r\n";
		}

		public void AdicionarColuna(string valor) {
			relatorio += "\t\t<td>" + valor + "</td>\r\n";
		}
		
		public void FinalizarLinha() {
			relatorio += "\t</tr>\r\n";
		}
		public string FinalizarRelatorio() {
			relatorio += "</table></body></html>";
			return relatorio;
		}
    }
}