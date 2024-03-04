using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.Models
{
   public class Category
   {
      
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Display Name")]      
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000, ErrorMessage = "Izmijenjena poruka")]
        public int DisplayOrder { get; set; }
   }
}
