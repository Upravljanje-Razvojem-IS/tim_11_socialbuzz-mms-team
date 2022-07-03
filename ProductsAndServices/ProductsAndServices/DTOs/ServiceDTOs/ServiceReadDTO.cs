namespace ProductsAndServices.DTOs.ServiceDTOs
{
    public class ServiceReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ServiceType { get; set; }
    }
}
