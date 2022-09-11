using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Cliente
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Identificacion { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Direccion { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string EstadoCliente { get; set; }
    }
}
