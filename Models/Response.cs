using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGiuaKy.Models
{
    public class Response
    {
        [Key]
        public int ResponeId { get; set; }
        [Required]
        public string? ResponeDescription { get; set; }
        [ForeignKey("UserID")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("ProductID")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
