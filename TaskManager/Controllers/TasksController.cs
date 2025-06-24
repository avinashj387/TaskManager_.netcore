using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Interfaces;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        var dto = tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        });

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(CreateTaskDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
            return BadRequest("Title is required.");

        var task = new TaskItem
        {
            Title = createDto.Title,
            IsCompleted = createDto.IsCompleted
        };

        var created = await _taskService.CreateTaskAsync(task);

        var dto = new TaskDto
        {
            Id = created.Id,
            Title = created.Title,
            IsCompleted = created.IsCompleted
        };

        return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateTaskDto updateDto)
    {
        var existing = await _taskService.GetTaskByIdAsync(id);
        if (existing == null)
            return NotFound();

        existing.Title = updateDto.Title;
        existing.IsCompleted = updateDto.IsCompleted;

        var success = await _taskService.UpdateTaskAsync(existing);
        if (!success)
            return StatusCode(500, "Failed to update");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _taskService.DeleteTaskAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> GetById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
            return NotFound();

        var dto = new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        };

        return Ok(dto);
    }

}
