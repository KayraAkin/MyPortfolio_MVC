﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioDbEntities1 db = new MyPortfolioDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblEducations.ToList();
            return View(values);
        }

        public ActionResult DeleteEducation(int id) 
        {
            var value = db.TblEducations.Find(id);
            db.TblEducations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(TblEducation model)
        {
            db.TblEducations.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id) 
        {
            var value = db.TblEducations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation model)
        {
            var value = db.TblEducations.Find(model.EducationId);
            value.SchoolName = model.SchoolName;
            value.Description = model.Description;
            value.EndDate = model.EndDate;
            value.StartDate = model.StartDate;
            value.Degree = model.Degree;
            value.Department = model.Department;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}