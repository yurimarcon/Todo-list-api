using Microsoft.AspNetCore.Mvc;
using testAPI_2.Data;
using testAPI_2.Models;

namespace testAPI_2.Controllers
{
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly AppDbContext _context;

        public TodoController(ILogger<TodoController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Todos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if(id == null)return BadRequest();

            return Ok(_context.Todos.FirstOrDefault(f => f.Id == id ));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Todo todo)
        {
            if(id != todo.Id) return BadRequest();

            var todoDb = _context.Todos.FirstOrDefault(f => f.Id == id);
            if(todoDb == null) return BadRequest();

            todoDb.Title = todo.Title;
            todoDb.Done = todo.Done;

            _context.Todos.Update(todoDb);
            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            var x = _context.Todos.Add(todo);
            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoDb = _context.Todos.FirstOrDefault(f => f.Id == id);
            if(todoDb == null) return BadRequest();
            _context.Remove(todoDb);
            _context.SaveChanges();

            return Ok($"Tarefa de id:{id} deletada com sucesso.");
        }
    }
}