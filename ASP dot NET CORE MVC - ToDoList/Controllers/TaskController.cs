using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Task;
using ToDoList.Domain.Filters.Task;

namespace ASP_dot_NET_CORE_MVC___ToDoList.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetCompletedTasks()
    {
        var result = await _taskService.GetCompletedTasks();
        return Json(new { data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        var response = await _taskService.Create(model);
        if (response.StatusCode == ToDoList.Domain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new { description = response.Description });
    }

    [HttpPost]
    public async Task<IActionResult> EndTask(long id)
    {
        var response = await _taskService.EndTask(id);
        if (response.StatusCode == ToDoList.Domain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new { description = response.Description });
    }

    [HttpPost]
    public async Task<IActionResult> TaskHandler(TaskFilter filter)
        {
        var response = await _taskService.GetTasks(filter);
        return Json(new { data = response.Data });
    }
}