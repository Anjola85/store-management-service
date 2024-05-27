using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("schedule")]
public class Schedule : BaseEntity
{
    [Column("store_id")]
    public string StoreId { get; set; }
    
    [ForeignKey("StoreId")]
    public Store Store { get; set; }

    [Column("special_day")]
    public long? SpecialDay { get; set; } // Epoch time

    [Column("description")]
    public string Description { get; set; }

    [Column("day_of_week")]
    public string DayOfWeek { get; set; }

    [Column("open_time")]
    public TimeSpan OpenTime { get; set; }

    [Column("close_time")]
    public TimeSpan CloseTime { get; set; }

    [Column("is_recurring")]
    public bool IsRecurring { get; set; }
}

