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
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Operation_Type")]
    public class Operation_TypeController : ControllerBase
    {
        private readonly ContextoTegra _context;
        public Operation_TypeController(ContextoTegra context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add_Operation_Type([FromBody] Operation_Type operation_Type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    operation_Type.Created_At = DateTime.Now;
                    operation_Type.Updated_At = DateTime.MinValue;
                    _context.Operation_Types.Add(operation_Type).State = EntityState.Added;
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
    }
}
