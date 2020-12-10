Liskov Substitution Principle
=============================

O princípio da substituição de Liskov, diz que as classes bases devem poder ser substituídas pelas classes derivadas em todos os contextos, ou seja, uma classe derivada não pode modificar o "contrato" da classe base.

Nosso projeto viola esse princípio na classe ProdutoRepository:

```C#
namespace solidInCsharp.Repository
{
    public class ProdutoRepository: BaseRepository<Produto, ProdutoRepository>
    {

        // Código omitido

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
```

Ao sobrescrever os métodos, e fazer eles lançarem excessão, a classe ProdutoRepository não pode ser substituir a classe BaseRepository em todas as suas atribuições.

Para corrigir, criamos uma nova classe BaseReadOnlyRepository, que somente possui os métodos de leitura e alteramos o ProdutoRepository para herdar desta classe.

```C#
namespace solidInCsharp.Repository
{
    public abstract class BaseReadOnlyRepository<T,K> : DbContext where T : class  where K : BaseReadOnlyRepository<T,K>
    {
        public BaseReadOnlyRepository(DbContextOptions<K> options)
            : base(options)
        { }

        protected DbSet<T> Items { get; set; }


        public IEnumerable<T> ListAll() {
            return this.Items.ToArray();
        }

        
        public IQueryable<T> Query() {
            return this.Items.AsQueryable();
        }


    }
}

using System;
using Microsoft.EntityFrameworkCore;
using solidInCsharp.Model;
using System.Linq;

namespace solidInCsharp.Repository
{
    public class ProdutoRepository: BaseReadOnlyRepository<Produto, ProdutoRepository>
    {

        public ProdutoRepository(DbContextOptions<ProdutoRepository> options)
            : base(options)
        {
            // trecho omitido
         }

    }
}
```

Com isso, nossa classe não mais ofende o LSP.