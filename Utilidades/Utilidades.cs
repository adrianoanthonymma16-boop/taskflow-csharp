using Tarefas;

namespace Utilidades;

public class GerenciadorTarefas()

{
    List<Tarefa> TarefasAConcluir = new List<Tarefa>();
    List<Tarefa> TarefasConcluidas = new List<Tarefa>();
    public void CriarTarefa()
    {
        while (true)
        {
            Console.WriteLine("Digite a descrição de sua tarefa");
             string? descricaoTarefa = Console.ReadLine();
             if (string.IsNullOrWhiteSpace(descricaoTarefa))
            {
                Console.WriteLine("Erro: a descrição não pode ser vazia");
                continue;
            }
            string contadorLetras = "";
            for (int i = 0; i < descricaoTarefa?.Length; i++)
            {
                char caractere = descricaoTarefa[i];
                if (!(char.IsDigit(caractere) || char.IsPunctuation(caractere) || char.IsSymbol(caractere)))
                {
                    contadorLetras += caractere.ToString(); 
                }
            }
            if (contadorLetras.Length < 5)
            {
                Console.WriteLine("Erro: a descrição deve ter pelo menos 5 letras");
                continue;
            }
            else
            {   
                descricaoTarefa = contadorLetras.Trim();
                TarefasAConcluir.Add(new Tarefa(descricaoTarefa));
                Console.WriteLine("Tarefa criada com sucesso!");
                break;
            }
        }
    }

    private void ExibirPendentes()
    {
        if (TarefasAConcluir.Count == 0)
        {
            Console.WriteLine("Não há tarefas cadastradas.");
            return;
        }

        int indiceTarefas = 0;
        foreach (var tarefa in TarefasAConcluir)
        {
            Console.WriteLine($" {indiceTarefas}. {tarefa.Descricao}");
            indiceTarefas++;
        }
    }

    public void ListarTarefasAConcluir()
    {
        ExibirPendentes();
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    public void ConcluirTarefa()
    {
        ExibirPendentes();
        if (TarefasAConcluir.Count == 0) return;
        Console.WriteLine("\nDigite o índice da tarefa que deseja concluir (Enter vazio para sair):");
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Saindo...");
                break;
            }
            if (!int.TryParse(input, out int indice))
            {
                Console.WriteLine("Erro: índice inválido. Tente novamente.");
                continue;
            }
            if (indice < 0 || indice >= TarefasAConcluir.Count)
            {
                Console.WriteLine("Erro: índice inválido. Tente novamente.");
                continue;
            }
            TarefasAConcluir[indice].Concluido = true;
            TarefasConcluidas.Add(TarefasAConcluir[indice]);
            TarefasAConcluir.RemoveAt(indice);
            Console.WriteLine($"Tarefa '{TarefasConcluidas[TarefasConcluidas.Count - 1].Descricao}' concluída com sucesso!");
            break;
        }
    }

    public void Dashboard()
    {
        var todas = TarefasAConcluir.Concat(TarefasConcluidas).ToList();
        int total = todas.Count;
        int concluidas = TarefasConcluidas.Count;
        int pendentes = TarefasAConcluir.Count;
        double porcentagem = total > 0 ? (double)concluidas / total * 100 : 0;

        int barSize = 20;
        int filled = (int)Math.Round(porcentagem / 100 * barSize);
        string barra = "[" + new string('#', filled) + new string('-', barSize - filled) + "]";

        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║         DASHBOARD            ║");
        Console.WriteLine("╚══════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine($" Total de tarefas: {total}");
        Console.WriteLine($" Concluídas:       {concluidas}");
        Console.WriteLine($" Pendentes:        {pendentes}");
        Console.WriteLine($" Progresso:        {porcentagem:F1}%");
        Console.WriteLine();
        Console.WriteLine($" {barra} {porcentagem:F0}%");
        Console.WriteLine();

        if (pendentes > 0)
        {
            Console.WriteLine(" Pendentes:");
            int i = 1;
            foreach (var t in TarefasAConcluir)
            {
                string desc = t.Descricao ?? "(sem descrição)";
                string checked_ = desc.Length > 40 ? desc[..40] + "..." : desc;
                Console.WriteLine($"   {i}. {checked_}");
                i++;
            }
        }
        else if (total > 0)
        {
            Console.WriteLine(" Todas as tarefas foram concluídas!");
        }
        else
        {
            Console.WriteLine(" Nenhuma tarefa cadastrada.");
        }

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    public void ListarTarefasConcluidas()
    {
        if (TarefasConcluidas.Count == 0)
        {
            Console.WriteLine("Não há tarefas concluídas.");
            return;
        }

        int indiceTarefas = 0;
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║     TAREFAS CONCLUÍDAS       ║");
        Console.WriteLine("╚══════════════════════════════╝");
        foreach (var tarefa in TarefasConcluidas)
        {
            string status = tarefa.Concluido ? "Concluída" : "Pendente";
            Console.WriteLine($" \n{indiceTarefas}. Descrição: {tarefa.Descricao}, Status: {status}");
            indiceTarefas++;
        }
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    public void ListarTodasTarefas()
    {
        var todas = TarefasAConcluir.Concat(TarefasConcluidas).ToList();
        if (todas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║       TODAS AS TAREFAS       ║");
        Console.WriteLine("╚══════════════════════════════╝");
        foreach (var tarefa in todas)
        {
            string status = tarefa.Concluido ? "Concluída" : "Pendente";
            string desc = tarefa.Descricao ?? "(sem descrição)";
            Console.WriteLine($" [{(tarefa.Concluido ? "X" : " ")}] {desc} - {status}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
}
