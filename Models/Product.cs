using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("product")]
public class Product : BaseEntity
{
    [Column("barcode_id")]
    public string BarcodeId { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("available_quantity")]
    public int AvailableQuantity { get; set; }

    [Column("restock_threshold")]
    public int RestockThreshold { get; set; }

    [Column("category_id")]
    public string CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Column("store_id")]
    public string StoreId { get; set; }

    [ForeignKey("StoreId")]
    public Store Store { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public ICollection<ProductDetail> ProductDetails { get; set; }
}