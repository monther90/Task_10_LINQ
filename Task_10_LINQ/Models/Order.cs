using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task_10_LINQ.Models;

[Table("orders", Schema = "sales")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Column("order_status")]
    public byte OrderStatus { get; set; }

    [Column("order_date", TypeName = "date")]
    public DateTime OrderDate { get; set; }

    [Column("required_date", TypeName = "date")]
    public DateTime RequiredDate { get; set; }

    [Column("shipped_date", TypeName = "date")]
    public DateTime? ShippedDate { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("staff_id")]
    public int StaffId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("StaffId")]
    public virtual Staff Staff { get; set; } = null!;

    [ForeignKey("StoreId")]
    public virtual Store Store { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}