using Utilidades;

namespace Programa;

public class Program
{
    public static void Main()
    {
        var gerenciador = new GerenciadorTarefas();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Criar tarefa\n"+
            "2. Listar tarefas pendentes\n"+
            "3. Concluir tarefa\n"+
            "4. Listar todas as tarefas\n"+
            "5. Listar tarefas concluídas\n"+
            "6. Dashboard\n"+
            "Enter vazio. Sair");
            string? opcao = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(opcao))
            {
                Console.WriteLine("Saindo...");
                break;
            }
            if (!int.TryParse(opcao, out int indice))
            {
                Console.WriteLine("Erro: índice inválido. Tente novamente.");
                continue;
            }
            if (indice < 0 || indice > 6)
            {
                Console.WriteLine("Erro: índice inválido. Tente novamente.");
                continue;
            }
            switch (indice)
            {
                case 1:
                    gerenciador.CriarTarefa();
                    break;
                case 2:
                    gerenciador.ListarTarefasAConcluir();
                    break;
                case 3:
                    gerenciador.ConcluirTarefa();
                    break;
                case 4:
                    gerenciador.ListarTodasTarefas();
                    break;
                case 5:
                    gerenciador.ListarTarefasConcluidas();
                    break;
                case 6:
                    gerenciador.Dashboard();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
            }
        }
    }
}