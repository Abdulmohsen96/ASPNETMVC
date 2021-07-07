using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMS.Models;

namespace UMS.Controllers {
    public class UserController : Controller {
        private readonly DataAccessLayer dataAccessLayer;

        public UserController() {
            dataAccessLayer = new DataAccessLayer();
        }

        //<-------------BEGIN OF GET METHODS----------->\\
        //<-------------THIS METHODS RESPONSIBLE FOR RENDERING VIEWS OF EACH ACTION------------->\\

        public IActionResult Login() {
            return View();
        }

        // GET: UserController
        public ActionResult Index() {
            IEnumerable<User> Users = dataAccessLayer.GetAllUsers();
            return View(Users);
        }

        // GET: UserController/Create
        public ActionResult Create() {
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id) {
            User user = dataAccessLayer.GetUser(id);
            return View(user);
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id) {
            User user = dataAccessLayer.GetUser(id);
            return View(user);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id) {
            User user = dataAccessLayer.GetUser(id);
            return View(user);
        }

        //<-------------END OF GET METHODS----------->\\

        //<--------------------||-------------------->\\

        //<-------------BEGIN OF POST METHODS----------->\\
        //<-------------THIS METHODS RESPONSIBLE FOR DOING THE ACTUAL DATABASE METHODS
        //<-------------WHEN THE SUBMIT BUTTON IS CLICKED WITHIN EACH METHOD VIEW------------->\\

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user) {
            try {
                dataAccessLayer.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user) {
            try {
                dataAccessLayer.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
                dataAccessLayer.DeleteUser(id);
                return RedirectToAction("Index");
        }

        //<-------------END OF POST METHODS----------->\\
    }
}
