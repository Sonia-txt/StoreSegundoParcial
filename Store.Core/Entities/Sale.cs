using Store.Core.Enums; // Agrega esta línea

namespace Store.Core.Entities;

public class Sale : EntityBase
{
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public SalesStatus Status { get; set; } // Ya no debería estar en rojo
}