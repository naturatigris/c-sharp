using System.ComponentModel.DataAnnotations;
namespace Book.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}