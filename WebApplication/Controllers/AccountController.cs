using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Security;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            List<Exercises> exercises = new List<Exercises>();


                using (MyDbContext db = new MyDbContext())
                {
                    account.Role = "user";
                    db.userAccount.Add(account);
                    db.SaveChanges();
                    var user = db.userAccount.Where(u => u.Username == account.Username && u.Password == account.Password 
                                                    && u.LastName == account.LastName).FirstOrDefault();

                    if (account.Sex == "male")
                    {
                        exercises = Exercises.MaleInitializePragram();
                        exercises.ForEach(ex => ex.UserID = user.UserID);
                        exercises.ForEach(ex => db.exercises.Add(ex));
                    }

                    if (account.Sex == "female")
                    {
                        exercises = Exercises.FemaleInitializePragram();
                        exercises.ForEach(ex => ex.UserID = user.UserID);
                        exercises.ForEach(ex => db.exercises.Add(ex));
                    }
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " succesfully registred.";


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Password"] = usr.Password.ToString();
                    Session["LastName"] = usr.LastName.ToString();
                    Session["Role"] = usr.Role.ToString();
                    if (usr.Role == "admin")
                        return RedirectToAction("Index");
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                if (Session["Role"].Equals("admin"))
                    return RedirectToAction("Index");
                return View();
            }
            else
                return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("AccessDenied");
            }
            else
            {
                Session["UserID"] = null;
                Session["Username"] = null;
                Session["Password"] = null;
                Session["LastName"] = null;
                return RedirectToAction("Login");
            }
        }

        // GET: User/Create
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserAccount userAccount)
        {
            try
            {
                // TODO: Add insert logic here
                List<Exercises> exercises = new List<Exercises>();


                    using (MyDbContext db = new MyDbContext())
                    {
                        db.userAccount.Add(userAccount);
                        db.SaveChanges();

                        var user = db.userAccount.Where(u => u.Username == userAccount.Username && u.Password == userAccount.Password 
                                                        && u.LastName == userAccount.LastName).FirstOrDefault();

                        if (userAccount.Sex == "male")
                        {
                            exercises = Exercises.MaleInitializePragram();
                            exercises.ForEach(ex => ex.UserID = user.UserID);
                            exercises.ForEach(ex => db.exercises.Add(ex));
                        }
                        if (userAccount.Sex == "female")
                        {
                            exercises = Exercises.FemaleInitializePragram();
                            exercises.ForEach(ex => ex.UserID = user.UserID);
                            exercises.ForEach(ex => db.exercises.Add(ex));
                        }
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }

                //return View(userAccount);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                UserAccount userAccount = db.userAccount.Find(id);
                return View(userAccount);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserAccount userAccount)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        db.Entry(userAccount).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(userAccount);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Details/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                UserAccount userAccount = db.userAccount.Find(id);
                if (userAccount == null)
                    return HttpNotFound();
                return View(userAccount);
            }
        }

        // GET: User/Delete/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                UserAccount userAccount = db.userAccount.Find(id);
                return View(userAccount);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                UserAccount userAccount = new UserAccount();

                if (ModelState.IsValid)
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        userAccount = db.userAccount.Find(id);
                        if (userAccount == null)
                            return HttpNotFound();

                        foreach (var ex in db.exercises)
                        {
                            if (ex.UserID == userAccount.UserID)
                            { 
                                db.exercises.Remove(ex);
                            }
                        }
                        db.SaveChanges();

                        db.userAccount.Remove(userAccount);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(userAccount);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}