using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly AplicationDbContext _context;
        public DetalleVentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public string ArticuloMasVendido()
        {
            string identi = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Max(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    identi = prueba.NombreProducto;
                }
            }
            return identi;
        }

        public async Task<ArticuloVendidoModel> MenosVendido()
        {
            var guardarId = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Min(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    guardarId = prueba.NombreProducto;
                }
            }
            var venta = await query.Where(x => x.NombreProducto == guardarId).FirstOrDefaultAsync();

            return venta;
        }

        public async Task<ArticuloVendidoModel> TraerPrueba()
        {
            var guardarId = "";
            var query = from liq in _context.DetalleVentas
                        group liq by liq.Nombre into g
                        select new ArticuloVendidoModel
                        {
                            NombreProducto = g.Key,
                            TotalVendido = g.Sum(x => x.Cantidad)
                        };
            var result = query.Max(x => x.TotalVendido);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalVendido)
                {
                    guardarId = prueba.NombreProducto;
                }
            }
            var venta = await query.Where(x => x.NombreProducto == guardarId).FirstOrDefaultAsync();

            return venta;
        }
    }
}
