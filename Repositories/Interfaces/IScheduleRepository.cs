using InventoryManagementService.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementService.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllSchedules();
        Task<Schedule> GetScheduleById(string id);
        Task<Schedule> CreateSchedule(Schedule schedule);
        Task UpdateSchedule(Schedule schedule);
        Task DeleteSchedule(string id);
    }
}
