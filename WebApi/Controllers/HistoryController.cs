using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("history")]
    public class HistoryController : ControllerBase
    {
        private ApiDbContext _context;

        public HistoryController(ApiDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<History>>> Get()
        {
            //var history = await _context.History.OrderBy(x=>x.date).ToListAsync();
            var history = await _context.History.OrderByDescending(x => x.date).ToListAsync();
            return history;
        }
        
    }
}