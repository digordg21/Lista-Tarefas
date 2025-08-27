using Tarefas.Models;
using Tarefas.Services;
using Tarefas.Repository;
using Tarefas.Data;
using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TarefaController : ControllerBase
{
    TarefaRepository repository;
    public TarefaController(TarefaRepository _repository)
    {
        repository = _repository;
    }

    // Listar todas as tarefas
    [HttpGet]
    public ActionResult<List<Tarefa>> GetAll()
    {
        return repository.GetAll();
    }

    // Listar uma tarefa pelo Id
    [HttpGet("{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var tarefa = repository.Get(id);
        if (tarefa is null)
            return NotFound();

        return tarefa;
    }

    // Criar uma nova tarefa
    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        repository.Add(tarefa);
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    // Deletar uma tarefa por id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = repository.Get(id);
        if (tarefa is null)
            return NotFound();

        repository.Delete(id);
        return NoContent();
    }

    // Atualizar uma tarefa por id
    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
            return BadRequest();

        repository.Update(tarefa);

        return NoContent();
    }

}