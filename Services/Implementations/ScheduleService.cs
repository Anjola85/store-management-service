using InventoryManagementService.Models;
using InventoryManagementService.Services.Interfaces;
using InventoryManagementService.Repositories.Interfaces;


namespace InventoryManagementService.Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            return await _repository.GetAllSchedules();
        }

        public async Task<Schedule> GetScheduleById(string id)
        {
            return await _repository.GetScheduleById(id);
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            return await _repository.CreateSchedule(schedule);
        }

        public async Task UpdateSchedule(string id, Schedule schedule)
        {
            await _repository.UpdateSchedule(schedule);
        }

        public async Task DeleteSchedule(string id)
        {
            await _repository.DeleteSchedule(id);
        }
    }
}
