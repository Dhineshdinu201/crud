using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample1;
using Sample1.Modals;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleDbContext _context;

        public ArticlesController(ArticleDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articles>>> Getstudent()
        {
            return await _context.student.ToListAsync();
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articles>> GetArticles(int id)
        {
            var articles = await _context.student.FindAsync(id);

            if (articles == null)
            {
                return NotFound();
            }

            return articles;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticles(int id, [FromBody]Articles articles)
        {
            if (id != articles.id)
            {
                return BadRequest();
            }

            _context.Entry(articles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Articles>> PostArticles([FromBody]Articles articles)
        {
            
            _context.student.Add(articles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticles", new { id = articles.id }, articles);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articles>> DeleteArticles(int id)
        {
            var articles = await _context.student.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            _context.student.Remove(articles);
            await _context.SaveChangesAsync();

            return articles;
        }
       
        private bool ArticlesExists(int id)
        {
            return _context.student.Any(e => e.id == id);
        }
        
    }
}
