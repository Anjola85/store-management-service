using InventoryManagementService.Models;

namespace InventoryManagementService.Services.Interfaces;

public interface IScheduleService
{
    Task<IEnumerable<Schedule>> GetAllSchedules();
    Task<Schedule> GetScheduleById(string id);
    Task<Schedule> CreateSchedule(Schedule schedule);
    Task UpdateSchedule(string id, Schedule schedule);
    Task DeleteSchedule(string id);
}
