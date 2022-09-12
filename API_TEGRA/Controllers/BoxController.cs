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
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Box")]
    public class BoxController : ControllerBase
    {
        private readonly ContextoTegra _context;
        public BoxController(ContextoTegra context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add_Box([FromBody] Box box)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    box.Created_At = DateTime.Now;
                    box.Updated_At = DateTime.MinValue;
                    _context.Boxes.Add(box).State = EntityState.Added;
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
        public async Task<IActionResult> Box_Edit([FromBody] Box box)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Boxes.Add(box).State = EntityState.Modified;
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
        public async Task<IActionResult> get_specific_box(int id_box)
        {
            try
            {
                Box cita = _context.Boxes.AsNoTracking().Single(g => g.Id_Box == id_box);
                return Ok(cita);
            }
            catch (Exception e)
            {
                return await Task.Run(() => BadRequest());
            }

        }
    }
}
