using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IDetalleVentaRepository
    {
        Task<ArticuloVendidoModel> TraerPrueba();
        Task<ArticuloVendidoModel> MenosVendido();
        string ArticuloMasVendido();
    }
}
