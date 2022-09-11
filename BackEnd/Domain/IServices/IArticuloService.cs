using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IArticuloService
    {
        Task SavedArticulo(Articulo articulo);
        Task<List<Articulo>> GetListArticulos();
        Task<Articulo> GetArticulo(string referencia);
        Task<Articulo> BuscarArticulo(string referencia);
        Task EliminarArticulo(Articulo articulo);
        Task UpdateCantidad(Articulo articulo);
        Task<List<Articulo>> GetListArticulosComprados();
        List<ArticuloFiltro> GetListArticulosConNombres();
        double TraerTotalGastos();
    }
}
