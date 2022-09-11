
using BackEnd.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaService _ventaService;

        public DetalleVentaController(IDetalleVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [Route("ArticuloMasVendido")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var venta = await _ventaService.TraerPrueba();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ArticuloMenosVendido")]
        [HttpGet]
        public async Task<IActionResult> GetMenos()
        {
            try
            {
                var venta = await _ventaService.MenosVendido();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
