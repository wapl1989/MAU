using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }

        [Required]
        [ForeignKey("Property")]
        public int IdProperty { get; set; }

        [Required]
        public byte[] File { get; set; } = new byte[0];

        [Required]
        public bool Enabled { get; set; }

        public Property? Property { get; set; }
    }
}
