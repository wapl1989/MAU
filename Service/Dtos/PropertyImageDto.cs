using Domain.Models;

namespace Service.Dtos
{
    public class PropertyImageDto
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[]? File { get; set; } 
        public bool Enabled { get; set; }

        public static explicit operator PropertyImage(PropertyImageDto dto)
        {
            PropertyImage propertyImage = new();

            propertyImage.IdPropertyImage = dto.IdPropertyImage;
            propertyImage.IdProperty = dto.IdProperty;
            propertyImage.Enabled = dto.Enabled;
            propertyImage.File = dto.File ?? new byte[0];

            return propertyImage;
        }
    }
}
