Interface Segregation Principle
===============================

O princípio de segregação de interface, diz que os clientes das nossas classes devem utilizar apenas as interfaces que eles precisam.

Nosso projeto viola esse princípio ao expor todos os métodos do EntityFramework para os clientes dos repositórios, o que poderia fazer com que eles façam usos das classes de formas que não pretendemos.

Para ajustar isso, criamos as seguintes interfaces:

```C#
namespace solidInCsharp.Repository
{
    public interface IReadRepository<T> where T : class  
    {
        public IEnumerable<T> ListAll();
    }

    public interface IWriteRepository<T> where T : class  
    {
        public void Add(T item);
        public void Remove(T item);
        public void Update(T item);

    }

    public interface IReadWriteRepository<T>: IReadRepository<T>, IWriteRepository<T> where T : class  
    {
    }

    public interface IUsuarioRepository: IReadWriteRepository<Usuario>
    {
        public Usuario ObterUsuario(string Email);
    }

    public interface IProdutoRepository: IReadRepository<Produto>
    {

    }
}

```

Também alteramos as implementações de repositório para usarem essas interfaces, atualizamos os serviços para usarem as novas interfaces e atualizamos o Startup para permitir a injeção de dependencias.

Desta forma, os clientes dos nossos repositórios tem acesso apenas aos métodos que queremos expor para eles.
