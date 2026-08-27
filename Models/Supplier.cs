namespace e_commerce_project.Models
{
    public class Supplier
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Items> Items { get; set; }
    }
}
