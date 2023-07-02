using Task;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Filters.Task;
using ToDoList.Domain.Response;

namespace Service.Interfaces;

public interface ITaskService
{
    Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model);

    Task<IBaseResponse<bool>> EndTask(long id);

    Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetTasks(TaskFilter filter);

    Task<IBaseResponse<IEnumerable<TaskViewModel>>> GetCompletedTasks();
}