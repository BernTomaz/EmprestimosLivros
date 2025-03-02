# EmprestimosLivros

## 📌 Sobre o Projeto

O EmprestimosLivros é um sistema web para gerenciamento de empréstimos de livros. Ele permite que usuários realizem login, façam requisições de empréstimos e gerenciem seu histórico. O projeto é desenvolvido em ASP.NET Core MVC com Entity Framework Core, proporcionando uma aplicação robusta e escalável.

## 🚀 Tecnologias Utilizadas
- **C#** (ASP.NET Core MVC)
- **Entity Framework Core**
- **SQL Server** (ou outro banco de dados suportado pelo EF Core)
- **Bootstrap** (para estilização)
- **jQuery & DataTables** (para interações dinâmicas)

## 📂 Estrutura do Projeto

```
EmprestimosLivros/
│-- Controllers/         # Controladores MVC
│   ├── EmprestimoController.cs
│   ├── HomeController.cs
│   ├── LoginController.cs
│
│-- Data/               # Configuração do Banco de Dados
│   ├── ApplicationDbContext.cs
│
│-- Dto/                # Objetos de Transferência de Dados (DTOs)
│   ├── UsuarioLoginDto.cs
│   ├── UsuarioRegisterDto.cs
│
│-- Migrations/         # Migrations do Banco de Dados
│   ├── 20250110192840_CriacaoDoBanco.cs
│   ├── 20250201191630_Banco2.cs
│   ├── 20250225033750_AdicionandoTabelaUsuarios.cs
│   ├── ApplicationDbContextModelSnapshot.cs
│
│-- Models/             # Modelos de Dados
│   ├── EmprestimosModel.cs
│   ├── ErrorViewModel.cs
│   ├── ResponseModel.cs
│   ├── UsuarioModel.cs
│
│-- Services/           # Serviços de Negócio
│   ├── EmprestimoService.cs
│   ├── LoginService.cs
│   ├── SenhaService.cs
│   ├── SessaoService.cs
│
│-- Views/              # Views MVC (CSHTML)
│   ├── Emprestimo/
│   ├── Home/
│   ├── Login/
│   ├── Shared/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│
│-- appsettings.json    # Configuração do aplicativo
│-- EmprestimosLivros.csproj  # Arquivo do projeto .NET
│-- Program.cs               # Configuração inicial do projeto

```

## 🔧 Como Executar o Projeto

### 1️⃣ Clonar o Repositório

```sh
git clone https://github.com/BernTomaz/EmprestimosLivros.git
cd EmprestimosLivros

```
### 2️⃣ Abrir o Projeto no Visual Studio

1. Abra o Visual Studio (versão 2022 ou superior recomendada).
2. Clique em "Abrir um projeto ou solução".
3. Navegue até a pasta do projeto e selecione o arquivo EmprestimosLivros.sln.
4. Aguarde o carregamento do projeto.


### 3️⃣ Restaurar Pacotes

No Gerenciador de Pacotes NuGet, execute:

```sh
dotnet restore
```
Ou, no Visual Studio, vá até Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes e execute:

```sh
Restore-Package
```

### 4️⃣ Configurar o Banco de Dados

No Visual Studio, abra o arquivo appsettings.json e configure a string de conexão com o SQL Server (ou outro banco de sua preferência).
No Console do Gerenciador de Pacotes NuGet, execute:

```sh
Update-Database
```
### 5️⃣ Executar o Projeto
Agora, basta rodar o projeto no Visual Studio:

1. Clique em Executar (F5) ou selecione EmprestimosLivros como Projeto de Inicialização e clique no botão de Iniciar.
2. O navegador abrirá automaticamente em http://localhost:5000 (ou outra porta configurada).


## ✨ Funcionalidades
✅ Cadastro e autenticação de usuários

✅ Registro e gerenciamento de empréstimos de livros

✅ Histórico de empréstimos

✅ Gerenciamento de sessões

✅ Interface responsiva com Bootstrap

## 🛠 Próximas Melhorias
- Implementação de notificações *por e-mail* sobre prazos de devolução
- Melhoria na interface com um design mais moderno
- Implementação de testes automatizados

## 📜 Licença
Este projeto está sob a licença **MIT**. Sinta-se livre para utilizá-lo e contribuir!

---
🔗 **Repositório:** [EmprestimosLivros](https://github.com/BernTomaz/EmprestimosLivros)

