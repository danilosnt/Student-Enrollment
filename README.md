# Sistema de Cadastro de Estudantes (IEL)

Aplicação web para gerenciamento de estudantes, desenvolvida em ASP.NET Core MVC.

O projeto implementa um sistema CRUD (Create, Read, Update, Delete) completo, com foco em validações robustas de dados, boas práticas de arquitetura MVC e uma interface de usuário moderna e interativa.

---

## 💻 Tecnologias

### Back-end
* **C# 12** e **.NET 8**
* **ASP.NET Core MVC**: Estrutura principal da aplicação.
* **Entity Framework Core 8**: ORM para acesso a dados (Code-First).

### Front-end
* **HTML5, CSS3, JavaScript**
* **Bootstrap 5**: Framework para estilização e responsividade.
* **jQuery** & **Toastr.js**: Bibliotecas para interatividade (máscara de CPF e notificações).

### Banco de Dados & Ferramentas
* **SQL Server LocalDB**
* **Visual Studio 2022**

---

## 📋 Funcionalidades Principais

* **Gerenciamento Completo (CRUD):** Criação, leitura, atualização e exclusão de estudantes.
* **Busca Dinâmica:** Filtro em tempo real na lista de estudantes por Nome, CPF ou Endereço.
* **Validações Avançadas:**
    * **CPF:** Validação matemática, unicidade no banco de dados e máscara de formato.
    * **Nome:** Permite apenas letras e espaços.
    * **Data de Conclusão:** Restrita ao período entre 1900 e a data atual.

---

## 📂 Estrutura do Projeto

A organização do projeto segue a convenção do ASP.NET Core MVC, com as responsabilidades separadas nas seguintes pastas principais:

### `/Models`
Define as classes que representam os dados da aplicação e suas regras de negócio.
* `Student.cs`: Entidade principal do sistema. Centraliza todos os atributos de um estudante e suas regras de validação (ex: `[Required]`, `[StringLength]`, e os atributos customizados).

### `/Views`
Contém os arquivos de interface do usuário (`.cshtml`) que são renderizados no navegador.
* **`/Estudantes`**: Telas relacionadas ao gerenciamento de estudantes.
    * `Index.cshtml`: Exibe a lista de todos os estudantes em formato de "cards" e o campo de busca.
    * `Create.cshtml`: Formulário para o cadastro de um novo estudante.
    * `Edit.cshtml`: Formulário para a edição de um estudante existente.
    * `Details.cshtml`: Página de visualização com todos os detalhes de um estudante.
    * `Delete.cshtml`: Tela de confirmação antes da exclusão de um registro.
* **`/Home`**: Páginas gerais da aplicação.
    * `Index.cshtml`: Página inicial da aplicação.
* **`/Shared`**: Elementos de layout reutilizáveis em todo o site.
    * `_Layout.cshtml`: O template mestre que define a estrutura comum (navbar, rodapé).
    * `_NotificationPartial.cshtml`: Componente para exibir as notificações "Toast".

### `/Controllers`
Responsáveis por receber as requisições, processar a lógica e retornar as `Views`.
* `EstudantesController.cs`: Orquestra todas as ações do CRUD de Estudantes (Listar, Criar, Salvar, Excluir). É o cérebro da aplicação, lidando com validações, busca e comunicação com o banco de dados.
* `HomeController.cs`: Controla as páginas estáticas, como a página `Index` inicial.

### `/Data`
Classes responsáveis pela configuração e comunicação com o banco de dados via Entity Framework Core.
* `ApplicationDbContext.cs`: A "ponte" entre a aplicação e o banco. Mapeia a classe `Student` para a tabela `Estudantes` no banco de dados.
* `DesignTimeDbContextFactory.cs`: Classe de suporte que permite que as ferramentas de linha de comando do EF Core (ex: para criar `migrations`) funcionem corretamente.

### `/Validation`
Contém os atributos de validação customizados para implementar regras de negócio específicas.
* `CpfValidationAttribute.cs`: Valida se um CPF é matematicamente válido, verificando se há sequência e os dígitos verificadores.
* `DateValidationAttribute.cs`: Valida se a data de conclusão está dentro do período permitido (de 1900 até a data atual).

---

## Como Executar Localmente

**Pré-requisitos:**
* .NET 8 SDK
* Visual Studio 2022 (com a carga de trabalho "ASP.NET e desenvolvimento web").

**Passos:**
1.  Clone o repositório para a sua máquina:
    ```bash
    git clone [https://github.com/danilosnt/Cadastro-de-Alunos.git](https://github.com/danilosnt/Cadastro-de-Alunos.git)
    ```
2.  Abra o **Projeto** no Visual Studio:
    * Inicie o Visual Studio e, na tela de início, selecione a opção **"Open a project or solution"**.
    * Navegue até a pasta que você acabou de clonar.
    * Selecione o arquivo de projeto **`StudentEnrollment.csproj`** e clique em "Open".

3.  Crie o Banco de Dados Local:
    * Com o projeto aberto, vá até o menu **Tools > NuGet Package Manager > Package Manager Console**.
    * Na console que se abrir, execute o seguinte comando para que o Entity Framework crie o banco de dados:
    ```powershell
    Update-Database
    ```
4.  Execute a Aplicação:
    * Pressione **`F5`** ou clique no botão de "Play" (▶) para compilar e iniciar o projeto. O site será aberto no seu navegador padrão.
