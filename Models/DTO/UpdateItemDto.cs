namespace e_commerce_project.Models.DTO
{
    public class UpdateItemDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SupplierId { get; set; }

    }
}
