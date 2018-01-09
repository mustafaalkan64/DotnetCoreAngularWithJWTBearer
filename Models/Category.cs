using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreProject.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public int CategoryName { get; set; }
        public ICollection<Category> Categories { get; set;} 
        public Category()
        {
            this.Categories = new Collection<Category>();
        }
    }
}