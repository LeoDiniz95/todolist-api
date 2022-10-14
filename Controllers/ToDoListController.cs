using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using todolist_api.Data;
using todolist_api.General;
using todolist_api.Repository;

namespace todolist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GeneralResult>> GetAll([FromServices] DataContext context)
        {
            var repository = new ToDoListRepository(context);
            return repository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResult>> Post([FromBody] string name, [FromServices] ToDoListRepository repository)
        {
            return repository.Add(name);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResult>> Put(int id, [FromServices] ToDoListRepository repository)
        {
            return repository.ChangeStatus(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralResult>> Delete(int id, [FromServices] ToDoListRepository repository)
        {
            return repository.Delete(id);
        }
    }
}
