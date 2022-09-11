using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Articulo
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Referencia { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
        public string EstadoCompra { get; set; }
        public double PrecioFinalCompra { get; set; }
        public string Comentarios { get; set; }
    }
}
