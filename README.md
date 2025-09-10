# Lista Telefônica

Aplicação de lista telefônica com **frontend em React** e **backend em .NET 8 (C#)**. Utiliza **MongoDB** para persistência de dados e comunicação via **API REST**. Permite cadastrar, editar e excluir contatos, com interface responsiva e estilizada em CSS.

## Tecnologias

- Frontend: React, CSS
- Backend: .NET 8 (C#)
- Banco de dados: MongoDB
- API: REST

## Funcionalidades

- Cadastro de contatos
- Edição de contatos
- Exclusão de contatos
- Interface responsiva
- Validações básicas de formulário

## Instalação

1. Clone o repositório:
```bash
git clone <URL_DO_REPOSITORIO>
Entre nas pastas do frontend e backend:

bash
Copiar código
cd frontend
npm install
cd ../backend
dotnet restore
Configure a conexão com o MongoDB no backend (arquivo appsettings.json).

Execução
Frontend:

bash
Copiar código
cd frontend
npm start
Backend:

bash
Copiar código
cd backend
dotnet run
Observações
Certifique-se de ter o Node.js, .NET 8 SDK e MongoDB instalados.

O frontend roda por padrão em http://localhost:3000.

O backend roda por padrão em http://localhost:5211.

Licença
MIT

Copiar código
