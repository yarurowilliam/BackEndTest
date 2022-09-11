using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {

        private readonly AplicationDbContext _context;

        public ArticuloRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Articulo> BuscarArticulo(string referencia)
        {
            var articulo = await _context.Articulos.Where(x => x.Referencia == referencia).FirstOrDefaultAsync();
            return articulo;
        }

        public async Task EliminarArticulo(Articulo articulo)
        {
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task<Articulo> GetArticulo(string referencia)
        {
            var articulo = await _context.Articulos.Where(x => x.Referencia == referencia).FirstOrDefaultAsync();
            return articulo;
        }

        public async Task<List<Articulo>> GetListArticulos()
        {
            var listaArticulo = await _context.Articulos.Where(x => x.Referencia != null).ToListAsync();
            return listaArticulo;
        }

        public async Task<List<Articulo>> GetListArticulosComprados()
        {
            var listaArticulo = await _context.Articulos.Where(x => x.EstadoCompra == "COMPRADO").ToListAsync();
            return listaArticulo;
        }

        public List<ArticuloFiltro> GetListArticulosConNombres()
        {
            var query = from a in _context.Articulos
                        select new ArticuloFiltro
                        {
                            Referencia = a.Referencia,
                            Nombre = a.Nombre,
                            Cantidad = a.Cantidad,
                            Precio = a.Precio,
                            Comentarios = a.Comentarios,
                            EstadoCompra = a.EstadoCompra
                        };
            var listaArticulo = query.ToList();
            return listaArticulo;
        }

        public async Task SavedArticulo(Articulo articulo)
        {
            _context.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public double TraerTotalGastos()
        {
            var listaArticulo = _context.Articulos.Where(x => x.EstadoCompra == "COMPRADO").ToList();
            double calcular = 0;
            foreach (var prueba in listaArticulo)
            {
                calcular = calcular+(prueba.Cantidad * prueba.PrecioFinalCompra);
            }
            var totalGastos = _context.Articulos.Where(x => x.EstadoCompra == "COMPRADO").Sum(x => x.PrecioFinalCompra);
            return calcular;
        }

        public async Task UpdateCantidad(Articulo articulo)
        {
            _context.Update(articulo);
            await _context.SaveChangesAsync();
        }
    }
}
