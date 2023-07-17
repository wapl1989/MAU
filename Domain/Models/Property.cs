using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodeInternal { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        [ForeignKey("Owner")]
        public int IdOwner { get; set; }

        public Owner? Owner { get; set; }

        public ICollection<PropertyImage>? PropertyImages { get; set; }

        public ICollection<PropertyTrace>? PropertyTraces { get; set; }        

    }
}
