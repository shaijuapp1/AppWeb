using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ToDosController : BaseApiController
    {
        private readonly DataContext _context;
        public ToDosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<ToDo>>> GetActivities()
        {
            return await _context.ToDos.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/fdfkdffdfd
        public async Task<ActionResult<ToDo>> GetActivity(int id)
        {
            return await _context.ToDos.FindAsync(id);
        }
        
    }
}