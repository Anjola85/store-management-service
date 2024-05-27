using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("category")]
public class Category : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
}