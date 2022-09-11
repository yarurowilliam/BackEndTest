using BackEnd.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IDetalleVentaService
    {
        Task<ArticuloVendidoModel> TraerPrueba();
        Task<ArticuloVendidoModel> MenosVendido();
        string ArticuloMasVendido();
    }
}
