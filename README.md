# Cadastro de Funcionários

Sistema de cadastro de funcionários desenvolvido em C# com .NET 9, utilizando acesso a dados via Dapper e SQL Server.

## Funcionalidades

- Adicionar funcionário
- Alterar funcionário
- Excluir funcionário
- Pesquisar funcionário por nome
- Listar todos os funcionários cadastrados

## Estrutura do Projeto

- **Entities**: Definição da entidade `Funcionario` com validações.
- **Controllers**: Lógica de interação com o usuário e orquestração das operações.
- **Repositories**: Acesso ao banco de dados SQL Server utilizando Dapper e procedures.
- **Settings**: Configuração da string de conexão.

## Como Executar

1. Certifique-se de ter o .NET 9 SDK instalado.
2. Configure o SQL Server LocalDB e crie o banco de dados `BDFuncionarios02` com as procedures necessárias.
3. Ajuste a string de conexão em `AppSettings.cs` se necessário.
4. Compile e execute o projeto via terminal ou Visual Studio 2022.

dotnet build dotnet run --project CadastroDeFuncionarios

## Observações

- O sistema é totalmente interativo via console.
- As operações de banco de dados dependem de procedures: `SP_InserirFuncionario`, `SP_AlterarFuncionario`, `SP_ExcluirFuncionario`.
- Os dados são validados antes de qualquer operação.

## Requisitos

- .NET 9
- SQL Server LocalDB
- Dapper

## Licença

Este projeto é de uso livre para fins de estudo.