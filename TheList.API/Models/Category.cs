using System.ComponentModel.DataAnnotations;

namespace TheList.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}