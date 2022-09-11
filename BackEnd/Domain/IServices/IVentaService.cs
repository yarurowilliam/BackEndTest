using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IVentaService
    {
        Task CreateVenta(Venta venta);
        Task<List<Venta>> GetListVentas();
        Task<Venta> GetVenta(int id);
        Task UpdateVenta(Venta venta);
        double TraerGanancias();
        Task<ClienteFiltro> GetMejorCliente();
    }
}
