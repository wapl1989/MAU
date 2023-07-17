using Domain.Models;

namespace Service.Dtos
{
    public class OwnerDto
    {
        public int IdOwner { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty ;
        public byte[] Photo { get; set; } = new byte[0];
        public DateTime Birthday { get; set; }

        public static explicit operator Owner(OwnerDto dto)
        {
            Owner owner = new();

            owner.IdOwner = dto.IdOwner;
            owner.Name = dto.Name;  
            owner.Address = dto.Address;
            owner.Photo = dto.Photo;
            owner.Birthday = dto.Birthday;

            return owner;
        }
    }
}
