namespace solidInCsharp.Service.Report
{
    public interface IReportGenerator
    {
		public void IniciarRelatorio();
		public void IniciarHeaders();
		public void AdicionarHeader(string valor);
		public void FinalizarHeaders();
		public void IniciarLinha();
		public void AdicionarColuna(string valor);
		public void FinalizarLinha();
		public string FinalizarRelatorio();
    }
}