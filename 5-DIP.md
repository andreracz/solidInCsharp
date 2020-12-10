Dependency Inversion Principle
==============================

O princípio de inversão de dependencia diz que nossas classes sempre devem depender de abstrações e não de concretos.

Seguindo esse principio favorecemos vários pontos importantes nos projetos, como a melhoria de manutenibilidade, testabilidade e extensabilidade do código.

Nosso projeto viola esse princípio em vários pontos, que listamos a seguir:

* Controllers dependem de services diretamente
* Services tem dependencia de outros services diretamente
* Services constroem outros services

Para resolução destes ponteos, devemos criar interfaces e em .Net o meio mais fácil é fazer a injeção de dependencias. Por exemplo, na classe UsuarioService:

```C#
namespace solidInCsharp.Service
{
    public class UsuarioService
    {
        private IUsuarioRepository repository;

        public UsuarioService(IUsuarioRepository repository){ 
            this.repository = repository;
        }

        public void CriarUsuario(string Email, string Name, string Password) {
            var user = this.repository.ObterUsuario(Email);
            if (user != null) {
                throw new Exception("Erro, usuário já existe");
            }
            user = new Usuario() { Email = Email, Nome = Name, Senha = new CriptografiaService().CriptografarSenha(Password)};
            this.repository.Add(user);
        }

        public string Login(string Email,  string Password) {
            var user = this.repository.ObterUsuario(Email);
            if (user == null || !new CriptografiaService().ValidarSenha(user.Senha, Password)) {
                throw new Exception("Erro, usuário ou senha incorreto");
            }
            return new JWTService().GerarToken(user);
        }


    }
}
```

Nesta classe, precisamos isolar a criação do JWTService e CriptoGrafiaService, além de criar uma interface para ela que permitirá que os controllers não tenham uma dependencia direta da implementação.

A implementação desta classe fica desta forma:

```C#
namespace solidInCsharp.Service
{
    public class UsuarioService: IUsuarioService
    {
        private IUsuarioRepository repository;

        private ICriptografiaService criptografiaService;

        private IJWTService jWTService;

        public UsuarioService(IUsuarioRepository repository, ICriptografiaService criptografia, IJWTService jwt){ 
            this.repository = repository;
            this.criptografiaService = criptografia;
            this.jWTService = jwt;
        }

        public void CriarUsuario(string Email, string Name, string Password) {
            var user = this.repository.ObterUsuario(Email);
            if (user != null) {
                throw new Exception("Erro, usuário já existe");
            }
            user = new Usuario() { Email = Email, Nome = Name, Senha = criptografiaService.CriptografarSenha(Password)};
            this.repository.Add(user);
        }

        public string Login(string Email,  string Password) {
            var user = this.repository.ObterUsuario(Email);
            if (user == null || !criptografiaService.ValidarSenha(user.Senha, Password)) {
                throw new Exception("Erro, usuário ou senha incorreto");
            }
            return jWTService.GerarToken(user);
        }


    }
}
```

Por fim, fazemos ajuste na classe de Startup para permitir a injeção de dependencias, e nosso projeto está concluído, seguindo os 5 princípios do SOLID!