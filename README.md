SOLID em C#
===========

Este repositorio foi criado para suportar o treinamento sobre princípios de SOLID em C#.

SOLID é um conjunto de princípios e boas práticas para desenvolvimento em Linguagens Orientadas a Objetos.
Os princípios foram criados em 2000 por Robert C. Martin, e o acrônimo SOLID foi criado por Michael Feathers.

Os principios do SOLID são:

| . | Nome do Principio               | Abr. | Descrição                                                                                                      |
|---|---------------------------------|------|----------------------------------------------------------------------------------------------------------------|
| S | Single Responsibility Principle | SRP  | Cada Classe ou modulo deve ter apenas uma razão para mudar                                                     |
| O | Open/Closed Principle           | OCP  | Entidades de Software (classes, módulos, funções), devem ser abertas a extensão, mas fechadas para modificação |
| L | Liskov Substitution Principle   | LSP  | Classes bases devem ser substituíveis pelas classes derivadas                                                  |
| I | Interface Segregation Principle | ISP  | Faça interfaces com alta granularidade, para cada cliente                                                      |
| D | Dependency Inversion Principle  | DIP  | Dependa de Abstrações, não de classes concretas                                                                |

O projeto aqui mostrado é um serviço REST, que, no commit inicial. viola estes princípios. Em cada Commit, ataco um dos princípios, corrigindo sua implementação.

A descrição das mudanças se encontra nos links abaixo:

* [1 - SRP - Principio da responsabilidade única](1-SRP.md) - Commit: [67e908a](https://github.com/andreracz/solidInCsharp/commit/67e908ae29520ee38bc1680a522e705c93b063aa)
* [2 - OCP - Principio Aberto/Fechado.md](2-OCP.md) - Commit: [ad89266](https://github.com/andreracz/solidInCsharp/commit/ad89266a944acce58f60d7a84a9d4c3b89b938be)
* [3 - LSP - Principio da Substituição de Liskov](3-LSP.md) - Commit: [8e04fae](https://github.com/andreracz/solidInCsharp/commit/8e04fae347970d027266a3417aa460206c156850)
* [4 - ISP - Principio de Segregação de Interfaces](4-ISP.md) - Commit: [8b0f804](https://github.com/andreracz/solidInCsharp/commit/8b0f80442a6b9d2941207598c18e93b76f7c633a)
* [5 - DIP - Principio da Inversão de Dependencia](5-DIP.md) - Commit [15972e8](https://github.com/andreracz/solidInCsharp/commit/15972e8cc52b43066c02c198eee0dbb9e457c940)
