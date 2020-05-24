using Microsoft.AspNetCore.Mvc;
using ContactsWebApp.Data;

namespace ContactsWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
    public class ContactsApiController : Controller
    {
        private Storage storage => Storage.Instance;

        /**
         * ContactsApiController constructor.
         * @param dbCtx Application database context
         */
        public ContactsApiController() { }

        // GET api/Contacts
        [HttpGet]
        public JsonResult Get()
        {
            return Json(storage.Contacts);
        }

        // GET api/Contacts/<id>
        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult Get(string id)
        {
            if (!int.TryParse(id, out var intId))
                return NotFound();

            var task = storage.GetById(intId);

            if (task == null)
                return NotFound();

            return Json(task);
        }

        // POST api/Contacts
        [HttpPost]
        public IActionResult Post([FromBody] Models.Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            storage.Add(contact);

            return CreatedAtRoute("GetContact", new { id = contact.ID }, contact);
        }

        // PUT api/Contacts/<id>
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Models.Contact contact)
        {
            if (!int.TryParse(id, out var intId))
                return NotFound();

            var task = storage.GetById(intId);

            if (task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            task.Update(contact);
            storage.Edit(task.ID, task);

            return Ok();
        }

        // DELETE api/Contacts/<id>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!int.TryParse(id, out var intId))
                return NotFound();

            var task = storage.GetById(intId);

            if (task == null)
                return NotFound();

            storage.Remove(task);

            return Ok();
        }
    }
}
