namespace assignment_two.DTOs.Product
{
    public class AddProductRequest
    {
        public string? ProductName { get; set; }
        public string? Manufacture { get; set; }
        public int CategoryId { get; set; }
    }
}