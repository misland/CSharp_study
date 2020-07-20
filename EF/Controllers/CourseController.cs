using EF.Infrastruct;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class CourseController : Controller
    {
        public ICourseRepository repository;
        public IStudentRepository stuRepository;

        public CourseController(IStudentRepository stuRepository,ICourseRepository couRepository)
        {
            this.repository = couRepository;
            this.stuRepository = stuRepository;
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = repository.GetAll().ToList();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(stuRepository.GetAll().ToList(), "SId", "Name");
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    repository.Add(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
