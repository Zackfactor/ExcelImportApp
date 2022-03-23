#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExcelImportApp.Data;
using ExcelImportApp.Model;
using ExcelImportApp.Services;

namespace ExcelImportApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ExcelImportAppContext _context;
        private readonly ExcelImportService _importService;

        public ClientController(ExcelImportAppContext context)
        {
            _context = context;
            // TODO: Very important, get from DI container
            _importService = new ExcelImportService();
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientModel()
        {
            return await _context.ClientModel.ToListAsync();
        }

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var file = Request.Form.Files[0];
            var models = _importService.ParseClientData(file);

            _context.ClientModel.AddRange(models);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
