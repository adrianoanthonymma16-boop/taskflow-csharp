namespace Tarefas;

public class Tarefa
{
    public string? Descricao {get;set;}
    public bool Concluido {get;set;}

    public Tarefa(string descricao, bool concluido = false)
    {
        Descricao = descricao;
        Concluido = concluido;
    }
}
