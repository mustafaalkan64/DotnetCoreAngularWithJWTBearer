using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreProject.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public ICollection<CustomerFavorites> CustomerFavorites { get; set;} 
        public Customer()
        {
            this.CustomerFavorites = new Collection<CustomerFavorites>();
        }
    }
}