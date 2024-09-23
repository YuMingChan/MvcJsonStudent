using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcCrudJson.Models;

namespace MvcCrudJson.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandler studentDBHandler = new StudentDBHandler();
            return View(studentDBHandler.GetStudentDetails());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentDBHandler studentDBHandler = new StudentDBHandler();
            return View(studentDBHandler.GetStudentDetails().Find(studentModel => studentModel.ID == id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel iList)
        {
            try
            {
                StudentDBHandler studentDBHandler = new StudentDBHandler();
                if (studentDBHandler.InsertStudent(iList))
                {
                    ModelState.Clear();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandler StudentHandler = new StudentDBHandler();
            return View(StudentHandler.GetStudentDetails().Find(studentModel => studentModel.ID == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel iList)
        {
            try
            {
                StudentDBHandler studentDBHandler = new StudentDBHandler();
                studentDBHandler.UpdateStudent(iList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentDBHandler studentDBHandler = new StudentDBHandler();
            return View(studentDBHandler.GetStudentDetails().Find(studentModel => studentModel.ID == id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                StudentDBHandler studentDBHandler = new StudentDBHandler();
                if (studentDBHandler.DeleteStudent(id))
                {
                    ModelState.Clear();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
