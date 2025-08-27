using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Repository;

public class TarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Tarefa> GetAll()
    {
        return _context.Tarefas.ToList();
    }

    public Tarefa? Get(int id) => _context.Tarefas.FirstOrDefault(t => t.Id == id);

    public void Add(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var tarefa = Get(id);
        if (tarefa is null) return;

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
    }

    public void Update(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
    }
}