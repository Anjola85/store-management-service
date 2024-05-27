using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("order_item")]
public class OrderItem : BaseEntity
{
    [Column("store_product_id")]
    public string StoreProductId { get; set; }

    [ForeignKey("StoreProductId")]
    public Product Product { get; set; }

    [Column("discount_percentage")]
    public decimal DiscountPercentage { get; set; }

    [Column("is_refunded")]
    public bool IsRefunded { get; set; }

    [Column("is_missing")]
    public bool IsMissing { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
}
