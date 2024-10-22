using System.ComponentModel.DataAnnotations.Schema;

namespace React_ASPNETCore.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
