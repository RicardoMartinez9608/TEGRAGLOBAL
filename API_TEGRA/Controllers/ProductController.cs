using API_TEGRA.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API_TEGRA.Modelo;

namespace API_TEGRA.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Product")]
    public class ProductController : ControllerBase
    {
        private readonly ContextoTegra _context;
        public ProductController(ContextoTegra context)
        {
            _context = context;
        }


        /// <summary>
        /// crar meta
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add_Product([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Created_At = DateTime.Now;
                    product.Updated_At = DateTime.MinValue;
                    _context.Products.Add(product).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    return Ok("Valores Almacenados exitosamente");
                }
                else
                {
                    return BadRequest(ModelState.ValidationState.ToString());
                }
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }
        }

        [HttpPut]
        public async Task<IActionResult> Product_Edit([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Add(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Valores Editados exitosamente");
                }
                else
                {
                    return BadRequest(ModelState.ValidationState.ToString());
                }
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }
        }
        [HttpGet]
        public async Task<IActionResult> get_specific_product(int id_product)
        {
            try
            {
                Product cita = _context.Products.AsNoTracking().Single(g => g.Id_Product == id_product);
                return Ok(cita);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            try
            {
                List<Product> cita = _context.Products.AsNoTracking().ToList();
                return Ok(cita);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
