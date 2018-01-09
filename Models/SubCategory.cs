using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreProject.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; }
        public string SubCategoryName { get; set;}
        public int CategoryId { get; set; }
        public Category Category { get; set;}
        public ICollection<Product> Product { get; set;} 
        public SubCategory()
        {
            this.Product = new Collection<Product>();
        }
    }
}