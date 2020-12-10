Sigle Responsability Principle
==============================

O Principio da responsabilidade única diz que os elementos de software (módulos, classes, funções, etc...) devem ter apenas uma responsabilidade. Nesse contexto responsabilidade é definido como "uma razão para mudar".

Para exemplificar, no projeto, a class UsuárioService tinha 4 responsabilidades, como pode ser visto no método Login:

```C#
namespace solidInCsharp.Service
{
    public class UsuarioService
    {
        // 1 - Responsabilidade do service (lógica de negócio)
        public string Login(string Email,  string Password) {
            // 2 - Responsabilidade de lógica de banco de dados
            var user = (from u in this.repository.Query() where u.Email == Email select u).FirstOrDefault();
            // 3 - Responsabilidade de cripgrafia de senha
            if (user == null || !ValidarSenha(user.Senha, Password)) {
                throw new Exception("Erro, usuário ou senha incorreto");
            }
            // 4 - Responsabilidade de gerar Token JWT
            return GerarToken(user);
        }
    }
}
```

Para fazer a correção, separamos cada uma das responsabilidades em suas classes.
Nosso método de Login fica então:

```C#
namespace solidInCsharp.Service
{
    public class UsuarioService
    {
        // 1 - Responsabilidade do service (lógica de negócio)
        public string Login(string Email,  string Password) {
            // 2 - Responsabilidade de lógica de banco de dados
            var user = repository.ObterUsuario(Email);
            // 3 - Responsabilidade de cripgrafia de senha
            if (user == null || ! new CriptografiaService().ValidarSenha(user.Senha, Password)) {
                throw new Exception("Erro, usuário ou senha incorreto");
            }
            // 4 - Responsabilidade de gerar Token JWT
            return new JWTService().GerarToken(user);
        }
    }
}
```
