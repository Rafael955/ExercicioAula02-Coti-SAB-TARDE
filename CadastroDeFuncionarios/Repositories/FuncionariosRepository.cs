using CadastroDeFuncionarios.Entities;
using CadastroDeFuncionarios.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace CadastroDeFuncionarios.Repositories
{
    public class FuncionariosRepository
    {
        public void Add(Funcionario funcionario)
        {
            using(var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var parameters = new
                {
                    ID = funcionario.Id,
                    NOME = funcionario.Nome,
                    MATRICULA = funcionario.Matricula,
                    CPF = funcionario.Cpf
                };

                connection.Execute(
                    "SP_InserirFuncionario",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var parameters = new
                {
                    ID = funcionario.Id,
                    NOME = funcionario.Nome,
                    MATRICULA = funcionario.Matricula,
                    CPF = funcionario.Cpf
                };

                connection.Execute(
                    "SP_AlterarFuncionario",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var parameters = new 
                {
                    ID = funcionario.Id,
                };

                connection.Execute(
                    "SP_ExcluirFuncionario",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Funcionario? GetById(Guid Id)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var query = "SELECT * FROM FUNCIONARIO WHERE ID = @Id";

                var parameters = new { Id };

                var funcionario = connection.QueryFirstOrDefault<Funcionario>(
                    query,
                    parameters);

                return funcionario;
            }
        }

        public List<Funcionario>? GetByName(string nome)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var query = "SELECT * FROM FUNCIONARIO WHERE NOME = @nome";

                var parameters = new { nome };

                var funcionarios = connection.Query<Funcionario>(
                    query,
                    parameters).ToList();

                return funcionarios;
            }
        }

        public List<Funcionario>? GetAll()
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                var query = "SELECT * FROM FUNCIONARIO";

                var funcionarios = connection.Query<Funcionario>(
                    query).ToList();

                return funcionarios;
            }
        }
    }
}
