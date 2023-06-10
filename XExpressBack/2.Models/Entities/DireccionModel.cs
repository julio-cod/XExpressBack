using System.ComponentModel.DataAnnotations;

namespace XExpressBack._2.Models.Entities
{
    public class DireccionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string? Direccion { get; set; }
        public string? Provincia { get; set; }
    }
}
