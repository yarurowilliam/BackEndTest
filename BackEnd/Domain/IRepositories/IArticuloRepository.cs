using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IArticuloRepository
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
