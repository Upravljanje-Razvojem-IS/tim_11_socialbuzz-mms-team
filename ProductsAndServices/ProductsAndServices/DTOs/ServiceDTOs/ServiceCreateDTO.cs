namespace ProductsAndServices.DTOs.ServiceDTOs
{
    public class ServiceCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int ServiceTypeID { get; set; }
    }
}
