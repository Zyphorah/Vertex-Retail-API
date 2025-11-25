namespace _521.tpfinal.web.Models
{
    public class Receipt
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; } = [];
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
