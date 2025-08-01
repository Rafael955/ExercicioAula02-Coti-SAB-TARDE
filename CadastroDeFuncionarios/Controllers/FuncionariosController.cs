using CadastroDeFuncionarios.Entities;
using CadastroDeFuncionarios.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFuncionarios.Controllers
{
    public class FuncionariosController
    {
        private readonly FuncionariosRepository funcionariosRepository = new FuncionariosRepository();

        public void AdicionarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            funcionario.Id = Guid.NewGuid();

            Console.WriteLine("\nINFORME OS DADOS DO FUNCIONARIO PARA CADASTRAR ABAIXO:\n");

            Console.Write("NOME ...........: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("MATRICULA ......: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("CPF ............: ");
            funcionario.Cpf = Console.ReadLine();

            ValidacaoFuncionario(funcionario);

            funcionariosRepository.Add(funcionario);

            Console.WriteLine("\nO FUNCIONÁRIO FOI CADASTRADO COM SUCESSO!");
        }

        public void AlterarFuncionario()
        {
            Console.Write("\nINFORME O ID DO FUNCIONARIO A SE ALTERAR .....: ");

            Guid idFuncionario;

            try
            {
                idFuncionario = Guid.Parse(Console.ReadLine());
            }
            catch
            {
                throw new InvalidCastException("FORMATO INVÁLIDO DE ID");
            }

            Funcionario funcionario = funcionariosRepository.GetById(idFuncionario);

            if (funcionario == null)
                throw new ApplicationException("FUNCIONÁRIO NÃO ENCONTRADO!");

            Console.WriteLine("\nDADOS DO FUNCIONARIO ATUAL:");

            Console.WriteLine("==================================================================");

            Console.WriteLine($"ID .............: {funcionario.Id}");
            Console.WriteLine($"NOME ...........: {funcionario.Nome}");
            Console.WriteLine($"MATRICULA ......: {funcionario.Matricula}");
            Console.WriteLine($"CPF ............: {funcionario.CpfFormatado}");

            Console.WriteLine("==================================================================");

            Console.WriteLine("\nINFORME OS DADOS DO FUNCIONARIO PARA ALTERAÇÃO ABAIXO:\n");

            Console.Write("NOME ...........: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("MATRICULA ......: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("CPF ............: ");
            funcionario.Cpf = Console.ReadLine();

            ValidacaoFuncionario(funcionario);

            funcionariosRepository.Update(funcionario);

            Console.WriteLine("\nO FUNCIONÁRIO FOI ALTERADO COM SUCESSO!");
        }

        public void ExcluirFuncionario()
        {
            Console.Write("\nINFORME O ID DO FUNCIONARIO A SE EXCLUIR .....: ");

            Guid idFuncionario;

            try
            {
                idFuncionario = Guid.Parse(Console.ReadLine());
            }
            catch
            {
                throw new InvalidCastException("FORMATO INVÁLIDO DE ID");
            }

            Funcionario funcionario = funcionariosRepository.GetById(idFuncionario);

            if (funcionario == null)
                throw new ApplicationException("FUNCIONÁRIO NÃO ENCONTRADO!");

            Console.WriteLine("\nDADOS DO FUNCIONARIO ATUAL:");

            Console.WriteLine("==================================================================");

            Console.WriteLine($"ID .............: {funcionario.Id}");
            Console.WriteLine($"NOME ...........: {funcionario.Nome}");
            Console.WriteLine($"MATRICULA ......: {funcionario.Matricula}");
            Console.WriteLine($"CPF ............: {funcionario.CpfFormatado}");

            Console.WriteLine("==================================================================");

            Console.Write("\nDESEJA REALMENTE EXCLUIR O FUNCIONÁRIO? [TECLE 'S' PARA CONFIRMAR] ...: ");
            var opcao = Console.ReadLine();

            if (opcao?.ToUpper() == "S")
            {
                funcionariosRepository.Delete(funcionario);
                Console.WriteLine("\nO FUNCIONÁRIO FOI EXCLUÍDO COM SUCESSO!");
            }
        }

        public void PesquisarFuncionario()
        {
            Console.Write("\nINFORME O NOME DO FUNCIONARIO PARA PESQUISAR .....: ");

            var nomeFuncionario = Console.ReadLine();

            List<Funcionario>? lista_funcionarios = funcionariosRepository.GetByName(nomeFuncionario);

            if (lista_funcionarios == null || lista_funcionarios.Count == 0)
                throw new ApplicationException("NENHUM FUNCIONÁRIO FOI ENCONTRADO COM ESTE NOME!");


            Console.WriteLine("\nDADOS DOS FUNCIONARIOS CADASTRADOS:");

            foreach (var funcionario in lista_funcionarios)
            {
                Console.WriteLine("==================================================================");

                Console.WriteLine($"ID .............: {funcionario.Id}");
                Console.WriteLine($"NOME ...........: {funcionario.Nome}");
                Console.WriteLine($"MATRICULA ......: {funcionario.Matricula}");
                Console.WriteLine($"CPF ............: {funcionario.CpfFormatado}");

                Console.WriteLine("==================================================================");
            }
        }

        public void ListarFuncionarios()
        {
            List<Funcionario>? lista_funcionarios = funcionariosRepository.GetAll();

            if (lista_funcionarios == null || lista_funcionarios.Count == 0)
                throw new ApplicationException("NENHUM FUNCIONÁRIO FOI ENCONTRADO!");


            Console.WriteLine("\nDADOS DOS FUNCIONARIOS CADASTRADOS:");

            foreach (var funcionario in lista_funcionarios)
            {
                Console.WriteLine("==================================================================");

                Console.WriteLine($"ID .............: {funcionario.Id}");
                Console.WriteLine($"NOME ...........: {funcionario.Nome}");
                Console.WriteLine($"MATRICULA ......: {funcionario.Matricula}");
                Console.WriteLine($"CPF ............: {funcionario.CpfFormatado}");

                Console.WriteLine("==================================================================");
            }
        }

        private void ValidacaoFuncionario(Funcionario funcionario)
        {
            // Validação
            var validationContext = new ValidationContext(funcionario, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(funcionario, validationContext, validationResults, true);

            // Tratamento dos resultados
            if (!isValid)
            {
                string errosValidacao = "ERROS DE VALIDAÇÃO:\n";

                foreach (var validationResult in validationResults)
                {
                    errosValidacao += "\t => " + validationResult.ErrorMessage.ToUpper() + "\n";
                }

                throw new ApplicationException(errosValidacao);
            }
        }
    }
}
