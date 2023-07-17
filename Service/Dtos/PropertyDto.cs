using Domain.Models;

namespace Service.Dtos
{
    public class PropertyDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = "";
        public int Year { get; set; }        
        public int IdOwner { get; set; }

        public static explicit operator Property(PropertyDto dto)
        {           
            Property property = new ();
            property.IdProperty = dto.IdProperty;
            property.Name = dto.Name;
            property.Address = dto.Address;
            property.Price = dto.Price;
            property.CodeInternal = dto.CodeInternal;
            property.Year = dto.Year;
            property.IdOwner = dto.IdOwner;

            return property;
        }
    }
}
