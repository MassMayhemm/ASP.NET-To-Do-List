namespace ToDoList.Domain.Enum;

public enum StatusCode
{
    TaskAlreadyExists = 1,
    TaskIsNotFound = 2,
    OK = 200,
    InternalServerError = 500
}