
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Venta venta)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                venta.EstadoVenta = "VIGENTE";
                venta.Fecha = DateTime.Now;
                await _ventaService.CreateVenta(venta);
                return Ok(new { message = "La venta se registro en el sistema"});
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListVentas")]
        [HttpGet]
        public async Task<IActionResult> GetListVentas()
        {
            try
            {
                var listVenta = await _ventaService.GetListVentas();
                return Ok(listVenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetMejorCliente")]
        [HttpGet]
        public async Task<IActionResult> MejorCliente(int id)
        {
            try
            {
                var venta = await _ventaService.GetMejorCliente();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("TraerGanancias")]
        [HttpGet]
        public IActionResult TraerGanancias()
        {
            try
            {
                var totalGanancias = _ventaService.TraerGanancias();
                return Ok(totalGanancias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venta = await _ventaService.GetVenta(id);
                return Ok(venta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(int id, Venta item)
        {
            if (id != item.Id)
            {
                return BadRequest(new { message = "Venta no encontrada" });
            }
            await _ventaService.UpdateVenta(item);
            return Ok(new { message = "Listo!" });
        }
    }
}
