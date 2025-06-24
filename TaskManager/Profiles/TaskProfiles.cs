// Profiles/TaskProfile.cs
using AutoMapper;
using TaskManager.Models;
using TaskManager.DTOs;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskItem, TaskReadDto>();
        CreateMap<CreateTaskDto, TaskItem>();
        CreateMap<TaskUpdateDto, TaskItem>();
        CreateMap<TaskItem, TaskUpdateDto>();
    }
}
