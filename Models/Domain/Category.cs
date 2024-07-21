using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models.Domain
{
    public class Category
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
