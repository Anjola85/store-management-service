using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementService.Models.Common;

public abstract class BaseEntity
{
    [Key]
    [Column("id")]
    public string Id { get; set; }

    [Column("created_at")]
    public long CreatedAt { get; set; }

    [Column("updated_at")]
    public long UpdatedAt { get; set; }

    [Column("deleted")]
    public bool Deleted { get; set; }
}