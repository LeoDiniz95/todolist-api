using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using todolist_api.Data;
using todolist_api.General;
using todolist_api.Repository;

namespace todolist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<GeneralResult> GetAll([FromServices] ItemsRepository repository)
        {
            return repository.GetAll();
        }

        [HttpPost]
        public ActionResult<GeneralResult> Post([FromBody] ItemRequest request, [FromServices] ItemsRepository repository)
        {
            return repository.Add(request.name);
        }

        [HttpPut("{id}")]
        public ActionResult<GeneralResult> Put(int id, [FromServices] ItemsRepository repository)
        {
            return repository.ChangeStatus(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneralResult> Delete(int id, [FromServices] ItemsRepository repository)
        {
            return repository.Delete(id);
        }
    }
}
