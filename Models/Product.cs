using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreProject.Models
{
    
    public static class ProductProperties {
        public static readonly IList<_KeyValuePair> OwnerTypes = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
           new _KeyValuePair { Key = 1, Value = "Sahibinden"} ,
           new _KeyValuePair { Key = 2, Value = "Emlak Ofisinden"} 
          });


            // Oda Sayısı
          public static readonly IList<_KeyValuePair> RoomCount = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
            new _KeyValuePair { Key = 1, Value = "1 + 0"},
            new _KeyValuePair { Key = 2, Value = "1 + 1"},
            new _KeyValuePair { Key = 3, Value = "2 + 1"},
            new _KeyValuePair { Key = 4, Value = "2 + 2"},
            new _KeyValuePair { Key = 5, Value = "3 + 1"},
            new _KeyValuePair { Key = 6, Value = "3 + 2"},
            new _KeyValuePair { Key = 7, Value = "4 + 1"},
            new _KeyValuePair { Key = 7, Value = "4 + 2"},
            new _KeyValuePair { Key = 8, Value = "5 + 1"},
          });

          // Bina Yaşı
          public static readonly IList<_KeyValuePair> BuildingAge = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
           new _KeyValuePair { Key = 1, Value = "0"},
           new _KeyValuePair { Key = 2, Value = "2"},
           new _KeyValuePair { Key = 3, Value = "3"},
           new _KeyValuePair { Key = 4, Value = "4"},
           new _KeyValuePair { Key = 5, Value = "5-10 Arası"},
           new _KeyValuePair { Key = 6, Value = "11-15 Arası"},
           new _KeyValuePair { Key = 7, Value = "16-20 Arası"},
           new _KeyValuePair { Key = 8, Value = "21-25 Arası"},
           new _KeyValuePair { Key = 9, Value = "26-30 Arası"},
          });

          // Bulunduğu Kat
          public static readonly IList<_KeyValuePair> FloorLocation = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
           new _KeyValuePair { Key = 1, Value = "Giriş Katı"},
           new _KeyValuePair { Key = 2, Value = "Zemin Katı"},
           new _KeyValuePair { Key = 3, Value = "Bahçe Katı"},
           new _KeyValuePair { Key = 4, Value = "Yüksek Giriş"},
           new _KeyValuePair { Key = 5, Value = "Kot 1"},
           new _KeyValuePair { Key = 6, Value = "Kot 2"},
           new _KeyValuePair { Key = 7, Value = "Kot 3"},
           new _KeyValuePair { Key = 8, Value = "1. Kat"},
           new _KeyValuePair { Key = 9, Value = "2. Kat"},
           new _KeyValuePair { Key = 10, Value = "3. Kat"},
           new _KeyValuePair { Key = 11, Value = "4. Kat"},
           new _KeyValuePair { Key = 12, Value = "5. Kat"},
           new _KeyValuePair { Key = 13, Value = "Çatı Katı"},
          });

          // Kat Sayısı
          public static readonly IList<_KeyValuePair> FloorNumber = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
           new _KeyValuePair { Key = 1, Value = 1},
           new _KeyValuePair { Key = 2, Value = 2},
           new _KeyValuePair { Key = 3, Value = 3},
           new _KeyValuePair { Key = 4, Value = 4},
           new _KeyValuePair { Key = 5, Value = 5},
           new _KeyValuePair { Key = 6, Value = 6},
           new _KeyValuePair { Key = 7, Value = 7},
           new _KeyValuePair { Key = 8, Value = 8},
           new _KeyValuePair { Key = 9, Value = 9},
           new _KeyValuePair { Key = 10, Value = 10},
           new _KeyValuePair { Key = 11, Value = 11},
           new _KeyValuePair { Key = 12, Value = 12},
           new _KeyValuePair { Key = 13, Value = 13},
          });


          // Isıtma Tipi
          public static readonly IList<_KeyValuePair> Heating = new ReadOnlyCollection<_KeyValuePair>
        (new List<_KeyValuePair> { 
           new _KeyValuePair { Key = 1, Value = "Doğalgaz Kombi"},
           new _KeyValuePair { Key = 2, Value = "Klima"},
           new _KeyValuePair { Key = 3, Value = "Soba"},
           new _KeyValuePair { Key = 4, Value = "Yok"},
           new _KeyValuePair { Key = 5, Value = "Doğalgaz Sobası"},
           new _KeyValuePair { Key = 6, Value = "Merkez Payölçer"},
           new _KeyValuePair { Key = 7, Value = "Kat Kaloriferi"},
           new _KeyValuePair { Key = 8, Value = "Isı Sobası"}
          });
    }
    

    public class Product
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string ProductName { get; set;}
        public SubCategory subCategory { get; set; }
        public int OwnerType { get; set;}
        public int RoomCount { get; set;}
        public int BuildingAge { get; set;}
        public int FloorLocation { get; set;}
        public int FloorNumber { get; set;}
        public int m2 { get; set;}
        public int Heating { get; set;}
        public decimal Cost { get; set;}
        public ICollection<CustomerFavorites> CustomerFavorites { get; set;} 
        public Product()
        {
            this.CustomerFavorites = new Collection<CustomerFavorites>();
        }
        
    }
}