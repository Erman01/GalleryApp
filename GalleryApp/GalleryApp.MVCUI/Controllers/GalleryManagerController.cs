using GalleryApp.Core.Contracts;
using GalleryApp.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace GalleryApp.MVCUI.Controllers
{
 //ekemanci@gmail.com   Erman@7971
    public class GalleryManagerController : Controller
    {
        IRepository<Gallery> _galleryRepository;
        public GalleryManagerController(IRepository<Gallery> galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public ActionResult Index()
        {
            List<Gallery> galleries = _galleryRepository.Collection().ToList();
            
            return View(galleries);
        }
        public ActionResult Create()
        {
            Gallery gallery = new Gallery();

            return View(gallery);
        }
        
        [HttpPost]
        public ActionResult Create(Gallery gallery, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(gallery);
            }
            else
            {
                if (file!=null)
                {
                    gallery.ImageUrl =/*User.Identity.GetUserId()+*/ gallery.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Gallery//") + gallery.ImageUrl);
                }
                _galleryRepository.Insert(gallery);
                _galleryRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string id)
        {
            Gallery gallery = _galleryRepository.Find(id);

            if (gallery==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(gallery);
            }
        }
        [HttpPost]
        public ActionResult Edit(string id,Gallery gallery,HttpPostedFileBase file)
        {
            Gallery galleryToEdit = _galleryRepository.Find(id);

            if (galleryToEdit==null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(gallery);
                }
                if (file!=null)
                {
                    galleryToEdit.ImageUrl = gallery.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Gallery//") + galleryToEdit.ImageUrl);
                }
                galleryToEdit.GalleryName = gallery.GalleryName;

                _galleryRepository.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            Gallery gallery = _galleryRepository.Find(id);

            if (gallery==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(gallery);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Gallery galleryToDelete = _galleryRepository.Find(id);

            if (galleryToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                _galleryRepository.Delete(id);
                _galleryRepository.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}