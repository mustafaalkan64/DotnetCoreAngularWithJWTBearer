using System.ComponentModel.DataAnnotations;

namespace AspnetCoreProject.Models
{
    public class CustomerFavorites
    {
        [Key]
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set;}
        public Product Product {get; set;}
        public Customer Customer {get; set;}
    }
}