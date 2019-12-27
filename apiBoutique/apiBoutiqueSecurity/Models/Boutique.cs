namespace apiBoutiqueSecurity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Boutique
    {

        [Key]
        public int ClothesID { get; set; }
        [Required]
        public string Shirt { get; set; }
        [Required]
        public string Dress { get; set; }
        [Required]
        public string Pant { get; set; }
        [Required]
        public string Accessory { get; set; }
    }
}