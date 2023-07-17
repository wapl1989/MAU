using Domain.Models;

namespace Service.Dtos
{
    public class PropertyTraceDto
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }  = string.Empty;
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public int IdProperty { get; set; }

        public static explicit operator PropertyTrace(PropertyTraceDto dto)
        {
            PropertyTrace propertyTrace = new();

            propertyTrace.IdPropertyTrace = dto.IdPropertyTrace;
            propertyTrace.DateSale = dto.DateSale;
            propertyTrace.Name = dto.Name;
            propertyTrace.Value = dto.Value;
            propertyTrace.IdProperty = dto.IdProperty;
            propertyTrace.Tax = dto.Tax;

            return propertyTrace;
        }
    }
}
