using System;
using Microsoft.EntityFrameworkCore;
using solidInCsharp.Model;
using System.Linq;

namespace solidInCsharp.Repository
{
    public class ProdutoRepository: BaseReadOnlyRepository<Produto, ProdutoRepository>, IProdutoRepository
    {

        public ProdutoRepository(DbContextOptions<ProdutoRepository> options)
			: base(options)
		{
			var itens =this.Items.ToArray();
			// Apenas para simular uma base já preenchida
			if (itens.Length == 0) {
				this.Items.Add(new Produto(){ Id="1", Nome="Produto 1", Preco = 10});
				this.Items.Add(new Produto(){ Id="2", Nome="Produto 2", Preco = 20});
				this.SaveChanges();
			}
		 }

    }
}