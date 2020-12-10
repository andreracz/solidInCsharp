Open/Closed Principle
=====================

O pricípio aberto/fechado, diz que um elemento de software deve ser aberto para extensão, mas fechado para modificações.

Nosso projeto de exemplo violava esse princípio na classe ProdutoReportService.cs, ao exigir que para criar um novo formato de relatório o método fosse completamente modificado.

Além disso, o método possui duas responsabilidades, uma com o formato de dados (formato do arquivo), e outra com o conteúdo (colunas e linhas), então este método viola também o [1-SRP.md](SRP).

```C#
namespace solidInCsharp.Service
{
    public class ProdutoReportService
    {
        //trecho omitido
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
            } // Se quiser adicionar um novo formato, tenho que modificar o código.
            throw new Exception("tipo de relatorio invalido");
        }
    }
}
```

Começamos nossa refatoração extraindo o comportamento comum dos relatórios tabularem, que possuem uma estrutura similar para todos os formatos:

* Início do Relatório
  * Inicio dos Headers
    * Colunas de Headers
  * Fim dos Headers
  * Inicio de Linha (N vezes)
    * Colunas das linhas
  * Fim da Linha
* Fim do Relatório

Para representar esse padrão, criamos a interface IReportGenerator:

```C#
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
```

Criamos também as implementações para CSV e HTML, e modificamos nosso método para gerar o relatório:

```C#
namespace solidInCsharp.Service
{
    public class ProdutoReportService
    {
        // trecho omitido
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
```

Com isso, nosso método de geração de relatório permite que novos formatos de relatórios sejam criados.

Para finalizar, criamos uma factory para construir os geradores de relatório e alteramos nosso Controller para a nova chamada.
