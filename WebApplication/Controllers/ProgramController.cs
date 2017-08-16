using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProgramController : Controller
    {
        List<Exercises> exercises = new List<Exercises>();
        string ProgramTitle = "";
        // GET: Program
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToRoute(new {
                    controller = "Account",
                    action = "AccessDenied"
                });
            }

            string userID = Session["UserID"].ToString();

            using (MyDbContext db = new MyDbContext())
            {
                foreach (var ex in db.exercises)
                {
                    if (ex.UserID.ToString() == userID)
                    {
                        exercises.Add(ex);
                    }
                }
                if (exercises != null)
                {
                    ViewBag.Message = exercises.ElementAt(0).ProgramTitle;
                    ProgramTitle = exercises.ElementAt(0).ProgramTitle;
                }
                else
                    ViewBag.Message = "Your Pragram";
                return View(exercises.ToList());
            }
        }

        // GET: Program/Details/5
        public ActionResult Details(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Exercises exercises = db.exercises.Find(id);
                if (exercises == null)
                    return HttpNotFound();
                return View(exercises);
            }
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Exercises exercise, string muscleGroup, string programTitle)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        exercise.UserID = Convert.ToInt32(Session["UserID"]);
                        exercise.MuscleGroup = muscleGroup;
                        exercise.ProgramTitle = programTitle;
                        db.exercises.Add(exercise);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return View(exercise);
            }
            catch
            {
                return View();
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Exercises exercises = db.exercises.Find(id);
                return View(exercises);
            }
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(Exercises ex)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        string userID = Session["UserID"].ToString();
                        db.Entry(ex).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        foreach (var exe in db.exercises)
                        {
                            if (exe.UserID == 0)
                            {
                                exe.UserID = Convert.ToInt32(userID);
                            }
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(ex);
            }
            catch
            {
                return View();
            }
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Exercises exercises = db.exercises.Find(id);
                return View(exercises);
            }
        }

        // POST: Program/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Exercises exercises = new Exercises();

                if (ModelState.IsValid)
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        exercises = db.exercises.Find(id);
                        if (exercises == null)
                            return HttpNotFound();
                        db.exercises.Remove(exercises);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(exercises);
            }
            catch
            {
                return View();
            }
        }
    }
}
