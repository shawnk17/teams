using System;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ResortProperties.Controllers
{

    public class ResortController : Controller
    {
        private readonly IResortPostsRepo _ResortPostRepo;

        public ResortController(IResortPostsRepo blogPostsRepo)
        {
            _ResortPostRepo = blogPostsRepo;
        }
        // GET: Resort
        public ActionResult Index()
        {
            return View(_ResortPostRepo.ListAll());
        }

        // GET: Resort/Details/5
        public ActionResult Details(int id)
        {
            return View(_ResortPostRepo.GetById(id));
        }

        // GET: Resort/Create
        public ActionResult Create()
        {
            return View(new ResortPost
            {
                PubDate = DateTime.Now
            });
        }

        // POST: Resort/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResortPost newResortPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ResortPostRepo.Add(newResortPost);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View(newResortPost);
        }

        // GET: Resort/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ResortPostRepo.GetById(id));
        }

        // POST: Resort/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResortPost editedResortPost)
        {
            try
            {
                _ResortPostRepo.Edit(editedResortPost);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(editedResortPost);
        }

        // GET: Resort/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ResortPostRepo.GetById(id));
        }

        // POST: Resort/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ResortPost ResortPostDelete)
        {
            try
            {
                _ResortPostRepo.Delete(ResortPostDelete);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(ResortPostDelete);
        }
    }
}