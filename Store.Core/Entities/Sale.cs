namespace Store.Core.Entities;
using Store.Core.Enums;

public class Sale : EntityBase
{
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    
}