using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;
        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Articulo articulo)
        {
            try
            {
                articulo.EstadoCompra = "PENDIENTE";
                articulo.PrecioFinalCompra = 0;
                articulo.Comentarios = "Agregar comentarios";
                await _articuloService.SavedArticulo(articulo);
                return Ok(new { message = "Articulo registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListArticulos")]
        [HttpGet]
        public async Task<IActionResult> GetListArticulos()
        {
            try
            {
                var listArticulo = await _articuloService.GetListArticulos();
                return Ok(listArticulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListArticulosComprados")]
        [HttpGet]
        public async Task<IActionResult> GetListArticulosComprados()
        {
            try
            {
                var listArticulo = await _articuloService.GetListArticulosComprados();
                return Ok(listArticulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListArticulosConNombres")]
        [HttpGet]
        public IActionResult GetListArticulosConNombres()
        {
            try
            {
                var listArticulo =_articuloService.GetListArticulosConNombres();
                return Ok(listArticulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("TraerTotalGastos")]
        [HttpGet]
        public IActionResult TraerTotalGastos()
        {
            try
            {
                var totalGastos = _articuloService.TraerTotalGastos();
                return Ok(totalGastos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{referencia}")]
        public async Task<IActionResult> Get(string referencia)
        {
            try
            {
                var articulo = await _articuloService.GetArticulo(referencia);
                return Ok(articulo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{referencia}")]
        public async Task<IActionResult> Delete(string referencia)
        {
            try
            {
                var categoria = await _articuloService.BuscarArticulo(referencia);
                if (categoria == null)
                {
                    return BadRequest(new { message = "No se encontro ningun articulo" });
                }
                await _articuloService.EliminarArticulo(categoria);
                return Ok(new { message = "El articulo fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{referencia}")]
        public async Task<IActionResult> UpdateCantidad(string referencia, Articulo item)
        {
            if (referencia != item.Referencia)
            {
                return BadRequest(new { message = "Articulo no encontrado" });
            }
            await _articuloService.UpdateCantidad(item);
            return Ok(new { message = "Se gestiono correctamente esta compra!" });
        }

    }
}
