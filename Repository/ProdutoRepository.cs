using System;
using Microsoft.EntityFrameworkCore;
using solidInCsharp.Model;
using System.Linq;

namespace solidInCsharp.Repository
{
    public class ProdutoRepository: BaseRepository<Produto, ProdutoRepository>
    {

        public ProdutoRepository(DbContextOptions<ProdutoRepository> options)
			: base(options)
		{
			var itens =this.Items.ToArray();
			if (itens.Length == 0) {
				this.Items.Add(new Produto(){ Id="1", Nome="Produto 1", Preco = 10});
				this.Items.Add(new Produto(){ Id="2", Nome="Produto 2", Preco = 20});
				this.SaveChanges();
			}
		 }

		public new void Add(Produto item) {
			throw new Exception("Products are readonly");
		}

		public new void Update(Produto item) {
			throw new Exception("Products are readonly");
		}

		public new void Remove(Produto item) {
			throw new Exception("Products are readonly");
		}
    }
}