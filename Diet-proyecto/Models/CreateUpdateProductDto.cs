using Diet_proyecto.Enum;
using System.ComponentModel.DataAnnotations;

namespace Diet_proyecto.Models
{
    public class CreateUpdateProductDto
    {
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Img { get; set; }

        public Status StatusType { get; set; }
    }
}