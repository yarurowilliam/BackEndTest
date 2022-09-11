using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class VentaRepository:IVentaRepository
    {
        private readonly AplicationDbContext _context;
        public VentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateVenta(Venta venta)
        {
            _context.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Venta>> GetListVentas()
        {
            var listVentas = await _context.Ventas.Where(x => x.Id != 0).ToListAsync();
            return listVentas;
        }

        public async Task<ClienteFiltro> GetMejorCliente()
        {
            string identi = "";
            var query1 = from liq in _context.Ventas
                        group liq by liq.ClienteId into g
                        select new VentaPrueba
                        {
                            ClienteId = g.Key,
                            TotalPagar = g.Sum(x => x.TotalPagar)
                        };

            var query = from a in query1
                        join s in _context.Clientes on a.ClienteId equals s.Identificacion
                        select new ClienteFiltro
                        {
                            Identificacion = a.ClienteId,
                            Nombre = s.Nombre + " " + s.Apellido,
                            TotalPagado = a.TotalPagar
                        };
            var result = query.Max(x => x.TotalPagado);
            foreach (var prueba in query)
            {
                if (result == prueba.TotalPagado)
                {
                    identi = prueba.Identificacion;
                }
            }
            var cliente = await query.Where(x => x.Identificacion == identi).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<Venta> GetVenta(int id)
        {
            var venta = await _context.Ventas.Where(x => x.Id == id)
                                                    .Include(x => x.listDetalleVentas)
                                                    .FirstOrDefaultAsync();
            
            return venta;
        }

        public double TraerGanancias()
        {
            var totalGanancias = _context.Ventas.Where(x => x.Id != 0).Sum(x => x.TotalPagar);
            return totalGanancias;
        }

        public async Task UpdateVenta(Venta venta)
        {
            _context.Update(venta);
            await _context.SaveChangesAsync();
        }

    }
}
