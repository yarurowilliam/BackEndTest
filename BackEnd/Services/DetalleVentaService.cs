using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class DetalleVentaService: IDetalleVentaService
    {
        private readonly IDetalleVentaRepository _ventaRepository;
        public DetalleVentaService(IDetalleVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public string ArticuloMasVendido()
        {
            return _ventaRepository.ArticuloMasVendido();
        }

        public async Task<ArticuloVendidoModel> MenosVendido()
        {
            return await _ventaRepository.MenosVendido();
        }

        public async Task<ArticuloVendidoModel> TraerPrueba()
        {
            return await _ventaRepository.TraerPrueba();
        }
    }
}
