using InventoryManagementService.Models;
using InventoryManagementService.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementService.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string _connectionString;

        public ScheduleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            var schedules = new List<Schedule>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT * FROM schedules", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            schedules.Add(new Schedule
                            {
                                Id = reader.GetString(reader.GetOrdinal("id")),
                                StoreId = reader.GetString(reader.GetOrdinal("store_id")),
                                SpecialDay = reader.IsDBNull(reader.GetOrdinal("special_day")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("special_day")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                DayOfWeek = reader.GetString(reader.GetOrdinal("day_of_week")),
                                OpenTime = reader.GetTimeSpan(reader.GetOrdinal("open_time")),
                                CloseTime = reader.GetTimeSpan(reader.GetOrdinal("close_time")),
                                IsRecurring = reader.GetBoolean(reader.GetOrdinal("is_recurring")),
                                CreatedAt = reader.GetInt64(reader.GetOrdinal("created_at")),
                                UpdatedAt = reader.GetInt64(reader.GetOrdinal("updated_at")),
                                Deleted = reader.GetBoolean(reader.GetOrdinal("deleted"))
                            });
                        }
                    }
                }
            }

            return schedules;
        }

        public async Task<Schedule> GetScheduleById(string id)
        {
            Schedule schedule = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT * FROM schedules WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            schedule = new Schedule
                            {
                                Id = reader.GetString(reader.GetOrdinal("id")),
                                StoreId = reader.GetString(reader.GetOrdinal("store_id")),
                                SpecialDay = reader.IsDBNull(reader.GetOrdinal("special_day")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("special_day")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                DayOfWeek = reader.GetString(reader.GetOrdinal("day_of_week")),
                                OpenTime = reader.GetTimeSpan(reader.GetOrdinal("open_time")),
                                CloseTime = reader.GetTimeSpan(reader.GetOrdinal("close_time")),
                                IsRecurring = reader.GetBoolean(reader.GetOrdinal("is_recurring")),
                                CreatedAt = reader.GetInt64(reader.GetOrdinal("created_at")),
                                UpdatedAt = reader.GetInt64(reader.GetOrdinal("updated_at")),
                                Deleted = reader.GetBoolean(reader.GetOrdinal("deleted"))
                            };
                        }
                    }
                }
            }

            return schedule;
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand(
                    "INSERT INTO schedules (id, store_id, special_day, description, day_of_week, open_time, close_time, is_recurring, created_at, updated_at, deleted) " +
                    "VALUES (@id, @store_id, @special_day, @description, @day_of_week, @open_time, @close_time, @is_recurring, @created_at, @updated_at, @deleted)", connection))
                {
                    command.Parameters.AddWithValue("@id", schedule.Id);
                    command.Parameters.AddWithValue("@store_id", schedule.StoreId);
                    command.Parameters.AddWithValue("@special_day", (object)schedule.SpecialDay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@description", schedule.Description);
                    command.Parameters.AddWithValue("@day_of_week", schedule.DayOfWeek);
                    command.Parameters.AddWithValue("@open_time", schedule.OpenTime);
                    command.Parameters.AddWithValue("@close_time", schedule.CloseTime);
                    command.Parameters.AddWithValue("@is_recurring", schedule.IsRecurring);
                    command.Parameters.AddWithValue("@created_at", schedule.CreatedAt);
                    command.Parameters.AddWithValue("@updated_at", schedule.UpdatedAt);
                    command.Parameters.AddWithValue("@deleted", schedule.Deleted);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return schedule;
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand(
                    "UPDATE schedules SET store_id = @store_id, special_day = @special_day, description = @description, day_of_week = @day_of_week, open_time = @open_time, close_time = @close_time, " +
                    "is_recurring = @is_recurring, created_at = @created_at, updated_at = @updated_at, deleted = @deleted WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", schedule.Id);
                    command.Parameters.AddWithValue("@store_id", schedule.StoreId);
                    command.Parameters.AddWithValue("@special_day", (object)schedule.SpecialDay ?? DBNull.Value);
                    command.Parameters.AddWithValue("@description", schedule.Description);
                    command.Parameters.AddWithValue("@day_of_week", schedule.DayOfWeek);
                    command.Parameters.AddWithValue("@open_time", schedule.OpenTime);
                    command.Parameters.AddWithValue("@close_time", schedule.CloseTime);
                    command.Parameters.AddWithValue("@is_recurring", schedule.IsRecurring);
                    command.Parameters.AddWithValue("@created_at", schedule.CreatedAt);
                    command.Parameters.AddWithValue("@updated_at", schedule.UpdatedAt);
                    command.Parameters.AddWithValue("@deleted", schedule.Deleted);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteSchedule(string id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("DELETE FROM schedules WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
