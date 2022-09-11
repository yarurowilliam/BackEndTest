using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Referencia { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
        public int VendaId { get; set; }
        public Venta Venta { get; set; }
    }
}
