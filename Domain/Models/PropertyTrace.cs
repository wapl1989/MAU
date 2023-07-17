using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PropertyTrace
    {
        [Key]
        public int IdPropertyTrace { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Value { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [ForeignKey("Property")]
        public int IdProperty { get; set; }

        public Property? Property { get; set; }
    }
}
