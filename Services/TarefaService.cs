using Tarefas.Models;

namespace Tarefas.Services;

public static class TarefaService
{
    static List<Tarefa> Tarefas { get; }
    static int nextId = 4;
    static TarefaService()
    {
        Tarefas = new List<Tarefa>
        {
            new Tarefa { Id = 1, Descricao = "Estudar .NET", Concluida = false },
            new Tarefa { Id = 2, Descricao = "Ir ao supermercado", Concluida = true },
            new Tarefa { Id = 3, Descricao = "Desligar os serviços do azure", Concluida = false }
        };
    }

    public static List<Tarefa> GetAll() => Tarefas;

    public static Tarefa? Get(int id) => Tarefas.FirstOrDefault(t => t.Id == id);

    public static void Add(Tarefa tarefa)
    {
        tarefa.Id = nextId++;
        Tarefas.Add(tarefa);
    }

    public static void Delete(int id)
    {
        var tarefa = Get(id);
        if(tarefa is null)
            return;

        Tarefas.Remove(tarefa);
    }

    public static void Update(Tarefa tarefa)
    {
        var index = Tarefas.FindIndex(t => t.Id == tarefa.Id);
        if(index == -1)
            return;

        Tarefas[index] = tarefa;
    }
}