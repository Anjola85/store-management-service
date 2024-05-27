using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("store")]
public class Store : BaseEntity
{
    [Column("owner_id")]
    public string OwnerId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("phone")]
    public string Phone { get; set; }

    [Column("is_visible")]
    public bool IsVisible { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}
