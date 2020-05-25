using Microsoft.AspNetCore.Mvc;
using ContactsWebApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace ContactsWebApp.Controllers
{
    /**
     * Contacts Controller
     */
    public class ContactsController : Controller
    {
        private Storage storage => Storage.Instance;

        public ContactsController() { }

        /**
         * GET: /Contacts/Create
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Models.Contact());
        }

        /**
         * POST: /Contacts/Create
         * http://go.microsoft.com/fwlink/?LinkId=317598
         * @param contact Contact model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Comment,Cell,Group")] Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                storage.Add(contact);

                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        /**
         * GET: /Contacts/Delete/<id>
         * @param id Contact ID
         */
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (!int.TryParse(id, out var intId))
                return NotFound();

            var contact = storage.GetById(intId);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        /**
         * POST: /Contacts/Delete/<id>
         * @param id Contact ID
         */
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var contact = storage.GetById(int.Parse(id));
            storage.Remove(contact);
            return RedirectToAction(nameof(Index));
        }

        /**
         * GET: /Contacts/Edit/<id>
         * @param id Contact ID
         */
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (!int.TryParse(id, out var intId))
                return NotFound();

            var contact = storage.GetById(intId);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        /**
         * POST: /Contacts/Edit/<id>
         * http://go.microsoft.com/fwlink/?LinkId=317598
         * @param id        Contact ID
         * @param contact Contact model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("ID,Name,Comment,Cell,Group")] Models.Contact contact)
        {
            var intId = int.Parse(id);
            if (intId != contact.ID)
                return NotFound();

            if (storage.GetById(intId) == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                storage.Edit(intId, contact);
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        /**
         * GET: [ /Contacts/, /Contacts/Index ]
         * @param sort Sort column and order
         */
        [HttpGet]
        public IActionResult Index(string sort)
        {
            ViewBag.IDSortParm = (sort == "ID" ? "ID_desc" : "ID");
            ViewBag.NameSortParm = (sort == "Name" ? "Name_desc" : "Name");
            ViewBag.CommentSortParm = (sort == "Comment" ? "Comment_desc" : "Comment");
            ViewBag.CellSortParm = (sort == "Cell" ? "Cell_desc" : "Cell");
            ViewBag.GroupSortParm = (sort == "Group" ? "Group_desc" : "Group");

            ViewData["sortJSON"] = sort;

            return View(this.GetSorted(sort).ToList());
        }

        /**
         * GET: /Contacts/GetJSON/<sort>
         * @param sort Sort column and order
         */
        [HttpGet]
        public IActionResult GetJSON(string sort)
        {
            return Json(GetSorted(sort).ToList());
        }

        /**
         * Returns a list of tasks sorted by the specified sort column and order.
         * @param sort Sort column and order
         */
        private IEnumerable<Models.Contact> GetSorted(string sort)
        {
            var contacts = storage.Contacts.AsEnumerable();

            switch (sort)
            {
                case "Name": contacts = contacts.OrderBy(s => s.Name); break;
                case "Name_desc": contacts = contacts.OrderByDescending(s => s.Name); break;
                case "ID": contacts = contacts.OrderBy(s => s.ID); break;
                case "ID_desc": contacts = contacts.OrderByDescending(s => s.ID); break;
                case "Comment": contacts = contacts.OrderBy(s => s.Comment); break;
                case "Comment_desc": contacts = contacts.OrderByDescending(s => s.Comment); break;
                case "Cell": contacts = contacts.OrderBy(s => s.Cell); break;
                case "Cell_desc": contacts = contacts.OrderByDescending(s => s.Cell); break;
                case "Group": contacts = contacts.OrderBy(s => s.Group); break;
                case "Group_desc": contacts = contacts.OrderByDescending(s => s.Group); break;
                default: contacts = contacts.OrderBy(s => s.Name); break;
            }
            return contacts;
        }
    }
}
