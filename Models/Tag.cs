using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("tag")]
public class Tag : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
