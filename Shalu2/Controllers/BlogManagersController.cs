using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shalu2.Models;

namespace Shalu2.Controllers
{
    public class BlogManagersController : Controller
    {
        private BlogManagerDBContext db = new BlogManagerDBContext();

        // GET: BlogManagers
        public ActionResult Index()
        {
            return View(db.BlogManagers.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult FailedLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logininput(LoginInfo input)
            {
            if (ModelState.IsValid)
            {
                string username = input.InputId;
                string userpassword = input.InputPassword;
                BlogManager BM = db.BlogManagers.Find(username);
                if (BM != null) {
                    if (BM.Password.Equals(userpassword))
                    {
                        return RedirectToAction("Index");
                    }
                }
                db.SaveChanges();
                return RedirectToAction("FailedLogin");
            }
            
            return RedirectToAction("NoUser");
        }


        // GET: BlogManagers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogManager blogManager = db.BlogManagers.Find(id);
            if (blogManager == null)
            {
                return HttpNotFound();
            }
            return View(blogManager);
        }

        // GET: BlogManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password")] BlogManager blogManager)
        {
            if (ModelState.IsValid)
            {
                db.BlogManagers.Add(blogManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogManager);
        }

        // GET: BlogManagers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogManager blogManager = db.BlogManagers.Find(id);
            if (blogManager == null)
            {
                return HttpNotFound();
            }
            return View(blogManager);
        }

        // POST: BlogManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password")] BlogManager blogManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogManager);
        }

        // GET: BlogManagers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogManager blogManager = db.BlogManagers.Find(id);
            if (blogManager == null)
            {
                return HttpNotFound();
            }
            return View(blogManager);
        }

        // POST: BlogManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BlogManager blogManager = db.BlogManagers.Find(id);
            db.BlogManagers.Remove(blogManager);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
