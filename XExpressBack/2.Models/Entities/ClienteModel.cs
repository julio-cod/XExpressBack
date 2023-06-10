using System.ComponentModel.DataAnnotations;

namespace XExpressBack._2.Models.Entities
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? DNI { get; set; }
        public string? Telefono { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
    }
}
