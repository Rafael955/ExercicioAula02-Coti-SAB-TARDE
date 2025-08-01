using CadastroDeFuncionarios.Controllers;

Retry:

try
{
    FuncionariosController funcionariosController = new FuncionariosController();

    Console.WriteLine("\t\t\t\t**** PROGRAMA CADASTRO DE FUNCIONÁRIOS ****");
    Console.WriteLine("\n\t\t\t\t\t**** MENU DE OPÇÕES ****");
    Console.WriteLine("\n\t[1] ADICIONAR FUNCIONÁRIO // [2] ALTERAR FUNCIONÁRIO // [3] EXCLUIR FUNCIONÁRIO");
    Console.WriteLine("\n\t[4] PESQUISAR FUNCIONÁRIO // [5] LISTAR FUNCIONÁRIOS CADASTRADOS // [6] SAIR DO PROGRAMA");
    Console.Write("\nINFORME A OPÇÃO ...: ");

    var opcao = Convert.ToInt16(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            funcionariosController.AdicionarFuncionario();
            break;
        case 2:
            funcionariosController.AlterarFuncionario();
            break;
        case 3:
            funcionariosController.ExcluirFuncionario();
            break;
        case 4:
            funcionariosController.PesquisarFuncionario();
            break;
        case 5:
            funcionariosController.ListarFuncionarios();
            break;
        case 6:
            Console.WriteLine("\nPROGRAMA FINALIZADO!");
            Thread.Sleep(3000);
            return;
        default:
            Console.WriteLine("\nOPÇÃO INVÁLIDA! TENTE NOVAMENTE.");
            break;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\nERRO: {ex.Message}");
}

Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA CONTINUAR ... ");
Console.ReadKey();
Console.Clear();
goto Retry;

