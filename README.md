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

### 2️⃣ Configurar o Ambiente
1. Instale as ferramentas necessárias:
```sh
dotnet tool install --global dotnet-ef
```
2. Restaure os pacotes do projeto:
```sh
dotnet restore
```

### 3️⃣ Configurar o Banco de Dados

2. Verifique sua conexão com um banco SQL Server (ou configure outro banco no `appsettings.json`).
3. Aplicar as migrations:
```sh
dotnet ef database update
```

### 4️⃣ Rodar o Projeto
```sh
dotnet run
```
Acesse: `http://localhost:5000` (ou a porta configurada).

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

