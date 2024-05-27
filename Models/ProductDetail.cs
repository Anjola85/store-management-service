using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("product_detail")]
public class ProductDetail : BaseEntity
{
    [Column("category_id")]
    public string CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Column("is_refrigerated_item")]
    public bool IsRefrigeratedItem { get; set; }

    [Column("weight_class")]
    public string WeightClass { get; set; }

    [Column("organic")]
    public bool Organic { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; }

    [Column("dimensions")]
    public string Dimensions { get; set; }

    [Column("name")]
    public string Name { get; set; }
}
