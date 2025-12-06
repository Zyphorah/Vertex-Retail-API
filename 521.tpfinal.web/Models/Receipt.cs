namespace _521.tpfinal.web.Models
{
    public class Receipt
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public List<ReceiptItem> Items { get; set; } = [];
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }

    public class ReceiptItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
