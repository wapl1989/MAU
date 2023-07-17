using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        public byte[]? Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<Property>? Properties { get; set; }
    }
}
