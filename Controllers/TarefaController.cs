using Tarefas.Models;
using Tarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Controllers;

[ApiController]
[Route("[controller]")]

public class TarefaController : ControllerBase
{
    public TarefaController()
    {

    }

    // Listar todas as tarefas
    [HttpGet]
    public ActionResult<List<Tarefa>> GetAll()
    {
        return TarefaService.GetAll();
    }

    // Listar uma tarefa pelo Id
    [HttpGet("{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var tarefa = TarefaService.Get(id);
        if (tarefa is null)
            return NotFound();

        return tarefa;
    }

    // Criar uma nova tarefa
    [HttpPost]
    public IActionResult Create(Tarefa tarefa)
    {
        TarefaService.Add(tarefa);
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    // Deletar uma tarefa por id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = TarefaService.Get(id);
        if (tarefa is null)
            return NotFound();

        TarefaService.Delete(id);
        return NoContent();
    }

    // Atualizar uma tarefa por id
    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
            return BadRequest();

        var tarefaExistente = TarefaService.Get(tarefa.Id);
        if (tarefaExistente is null)
            return NotFound();

        TarefaService.Update(tarefa);

        return NoContent();
    }

}