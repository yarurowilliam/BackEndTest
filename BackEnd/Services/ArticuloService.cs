using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<Articulo> BuscarArticulo(string referencia)
        {
            return await _articuloRepository.BuscarArticulo(referencia);
        }

        public async Task EliminarArticulo(Articulo articulo)
        {
            await _articuloRepository.EliminarArticulo(articulo);
        }

        public async Task<Articulo> GetArticulo(string referencia)
        {
            return await _articuloRepository.GetArticulo(referencia);
        }

        public async Task<List<Articulo>> GetListArticulos()
        {
            return await _articuloRepository.GetListArticulos();
        }

        public async Task<List<Articulo>> GetListArticulosComprados()
        {
            return await _articuloRepository.GetListArticulosComprados();
        }

        public List<ArticuloFiltro> GetListArticulosConNombres()
        {
            return _articuloRepository.GetListArticulosConNombres();
        }

        public async Task SavedArticulo(Articulo articulo)
        {
            await _articuloRepository.SavedArticulo(articulo);
        }

        public double TraerTotalGastos()
        {
            return _articuloRepository.TraerTotalGastos();
        }

        public async Task UpdateCantidad(Articulo articulo)
        {
            await _articuloRepository.UpdateCantidad(articulo);
        }
    }


}
