<p align="center">
  <img src="https://github.com/leandrochavesf/csharp-quiz-car-api/blob/master/.github/quizzapp-logo-dark.png?raw=true",>
  <br />
  <br />
  <br />
<p align="center">Discover your knowledge about the car factories&#x27; history.</p>
  <!-- <img src="https://img.shields.io/github/issues/.../...">
  <img src="https://img.shields.io/github/forks/.../...">
  <img src="https://img.shields.io/badge/...">
  <img src="https://img.shields.io/github/stars/.../...">
  <img src="https://img.shields.io/github/license/.../..."> -->

   <p align="center">
      <a href="#sobre-o-desafio">Sobre o desafio</a>
      <strong>|</strong>
      <a href="#recursos-e-funcionalidades">Recursos e Funcionalidades</a>
      <strong>|</strong>
      <a href="#instalação">Instalação</a>
      <strong>|</strong>
      <a href="#project-tree">Project Tree</a>
      <strong>|</strong>
      <a href="#license">License</a>
   </p>

</p>

# QuizzApp API

:robot: Challenge - [ Mobile Technical Challenge](#)

## Sobre o desafio

Desenvolver uma aplicação mobile simples sobre a origem das montadoras (país de origem), onde o usuário deverá responder algumas perguntas e obter seu resultado em forma de porcentagem no final do questionário.

Confira o repositório do App Mobile para mais informações: [Link do repositório][github-quizcar-mobile]

## Recursos e Funcionalidades

#### Tecnologias e Libraries usadas neste projeto

- [Microsoft.VisualStudio.Web.CodeGeneration.Design][ms-vs-web-cg-design]
- [Microsoft.EntityFrameworkCore.Design][ms-efc-design]
- [Microsoft.EntityFrameworkCore.InMemory][ms-efc-inmemory]
- [Microsoft.EntityFrameworkCore.SqlServer][ms-efc-sqlserver]
- [ASPNET Code Generator][aspnet-codegenerator]
- [Json to C# Convert][json-to-csharp]
- [VS Code][vscode] e [Insomnia][insomnia]

#### Recursos desenvolvidos e futuros

- [x] CRUD das Perguntas
- [ ] Persistencia de dados em Database SQL
- [ ] Criação de Migrations do DB
- [ ] Validação de dados de entrada
- [ ] Ajustes para rodar em Docker
- [ ] Aplicação de Testes unitários
- [ ] Registro e autenticação (Opcional)

## Instalação

#### Iniciar App Flutter

Para clonar e executar esta aplicação, você vai precisar do [Git][git], [MS .NET][dotnet] e [VSCode][vscode] instalados no seu computador.

Linhas de comando:

```bash
# Clone this repository
$ git clone https://github.com/leandrochavesf/csharp-quiz-car-api.git

# Go into the repository
$ cd csharp-quiz-car-api

# Install dependencies
$ dotnet restore

# Run the App
$ dotnet watch run
```

#### Observações

Para facilitar os testes, o APP Mobile está consumindo dados JSON via My-Json-Server ([Link do JSON][json-server-web]).

Para atualizar este projeto, atente-se também em atualizar a const `QUESTION_URL` em [consts_api.dart][consts_api.dart] do APP Mobile.

Você também pode usar o [Insomnia][insomnia] e importar o [Insomnia file](./insomnia-calls.json) para testar as rotas deste projeto.

#### Insights

Você também pode conferir alguns insights e outros dados relatados durante o desenvolvimento em [Insights.md](./.github/INSIGHTS.MD)

## Project Tree

Abaixo uma lista dos arquivos mais relevantes do projeto

```
QuizCarApi
├─ .github
│  └─ INSIGHTS.md
├─ Controllers
│  └─ QuestionItemsController.cs
├─ LICENSE.md
├─ Program.cs
├─ QuizCarApi.csproj
├─ README.md
├─ Startup.cs
├─ insomnia-calls.json
└─ models
   ├─ QuestionContext.cs
   ├─ QuestionItem.cs
   └─ QuestionItemDTO.cs

```

## License

This project is under the MIT license. See the [LICENSE](./LICENSE.md) for more information.

---

#### Made by Leandro Chaves [Get in touch!](https://leandrochaves.me/linkedin)

<!-- ## Internal Links  -->

[github-quizcar-mobile]: https://github.com/leandrochavesf/flutter-quiz-car
[consts_api.dart]: https://github.com/leandrochavesf/flutter-quiz-car/blob/master/lib/shared/consts_api.dart

<!-- Resources -->

[ms-vs-web-cg-design]: https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/
[ms-efc-design]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/
[ms-efc-inmemory]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/
[ms-efc-sqlserver]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/
[json-to-csharp]: https://quicktype.io/csharp/
[aspnet-codegenerator]: https://www.nuget.org/packages/dotnet-aspnet-codegenerator/

<!-- Editor -->

[vscode]: https://code.visualstudio.com/

<!-- Technologies -->

[git]: https://git-scm.com
[dotnet]: https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro
[json-server-web]: https://my-json-server.typicode.com/leandrochavesf/flutter-quiz-car/Questions
[insomnia]: https://insomnia.rest/download/
[docker]: https://www.docker.com
