# EmprestimosLivros

## 📌 Sobre o Projeto
O **EmprestimosLivros** é um sistema web para gerenciamento de empréstimos de livros. Ele permite que usuários realizem login, façam requisições de empréstimos e gerenciem seu histórico. O projeto é baseado no **ASP.NET Core MVC** com **Entity Framework**.

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
│   ├── LoginController.cs
│
│-- Dto/                # Objetos de Transferência de Dados (DTOs)
│   ├── UsuarioLoginDto.cs
│
│-- Services/           # Serviços de Negócio
│   ├── LoginService/
│   │   ├── ILoginInterface.cs
│   │   ├── LoginService.cs
│   ├── SenhaService/
│   │   ├── ISenhaInterface.cs
│   │   ├── SenhaService.cs
│   ├── SessaoService/
│   │   ├── ISessaoInterface.cs
│   │   ├── SessaoService.cs
│
│-- Views/              # Views MVC (CSHTML)
│   ├── Home/
│   │   ├── Index.cshtml
│   ├── Login/
│   │   ├── Index.cshtml
│   │   ├── Registrar.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _LayoutDeslogado.cshtml
│
│-- EmprestimosLivros.csproj  # Arquivo do projeto .NET
│-- Program.cs               # Configuração inicial do projeto
```

## 🔧 Como Executar o Projeto

### 1️⃣ Clonar o Repositório
```sh
git clone https://github.com/BernTomaz/EmprestimosLivros.git
cd EmprestimosLivros
```

### 2️⃣ Configurar o Banco de Dados
1. Verifique sua conexão com um banco SQL Server (ou configure outro banco no `appsettings.json`).
2. Aplicar as migrations:
```sh
dotnet ef database update
```

### 3️⃣ Rodar o Projeto
```sh
dotnet run
```
Acesse: `http://localhost:5000` (ou a porta configurada).

## ✨ Funcionalidades
- Cadastro e autenticação de usuários
- Registro de empréstimos de livros
- Gerenciamento de sessões
- Interface responsiva com Bootstrap

## 📜 Licença
Este projeto está sob a licença **MIT**. Sinta-se livre para utilizá-lo e contribuir!

---
🔗 **Repositório:** [EmprestimosLivros](https://github.com/BernTomaz/EmprestimosLivros)

