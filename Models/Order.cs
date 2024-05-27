using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementService.Models.Common;

namespace InventoryManagementService.Models;

[Table("order")]
public class Order : BaseEntity
{
    [Column("delivery_status")]
    public string DeliveryStatus { get; set; }

    [Column("refund_status")]
    public string RefundStatus { get; set; }

    [Column("total_price")]
    public decimal TotalPrice { get; set; }

    [Column("customer_id")]
    public string CustomerId { get; set; }

    [Column("driver_id")]
    public string DriverId { get; set; }

    [Column("delivery_type")]
    public string DeliveryType { get; set; }

    [Column("address")]
    public string Address { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
