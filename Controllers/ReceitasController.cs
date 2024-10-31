using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceitasApi.Data;
using ReceitasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceitasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly DataContext _context;

        public ReceitasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
            return await _context.Receitas.Include(r => r.Categoria).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _context.Receitas.Include(r => r.Categoria).FirstOrDefaultAsync(r => r.Id == id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceita), new { id = receita.Id }, receita);
        }
    }
}