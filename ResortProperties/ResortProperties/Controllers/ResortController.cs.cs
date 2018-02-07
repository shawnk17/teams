using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResortProperties.Models;
using ResortProperties.Models.ManageViewModels;
using ResortProperties.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;


namespace ResortProperties.Controllers
{
    public class Resort : Controller
    {
        private readonly IResortPostsRepo _blogPostRepo;

        public Resort(IResortPostsRepo blogPostsRepo)
        {
            _blogPostRepo = blogPostsRepo;
        }
        // GET: Blog
        public ActionResult Index()
        {
            return View(_blogPostRepo.ListAll());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View(new ResortPost
            {
                PubDate = DateTime.Now
            });
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResortPost newResortPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _blogPostRepo.Add(newResortPost);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View(newResortPost);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResortPost editedBlogPost)
        {
            try
            {
                _blogPostRepo.Edit(editedBlogPost);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(editedBlogPost);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ResortPost blogPostDelete)
        {
            try
            {
                _blogPostRepo.Delete(blogPostDelete);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(blogPostDelete);
        }
    }
}