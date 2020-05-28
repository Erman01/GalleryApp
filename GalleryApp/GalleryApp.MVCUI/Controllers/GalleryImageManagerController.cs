using GalleryApp.Core.Contracts;
using GalleryApp.Core.Models;
using GalleryApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleryApp.MVCUI.Controllers
{
    public class GalleryImageManagerController : Controller
    {
        IRepository<GalleryImage> _galleryImageRepository;
        IRepository<Gallery> _galleryRepository;
        public GalleryImageManagerController(IRepository<GalleryImage> galleryImageRepository, IRepository<Gallery> galleryRepository)
        {
            _galleryImageRepository = galleryImageRepository;
            _galleryRepository = galleryRepository;
        }
        public ActionResult Index()
        {
            List<GalleryImage> galleryImages = _galleryImageRepository.Collection().ToList();

            return View(galleryImages);
        }
        public ActionResult Create()
        {
            GalleryImageManagerViewModel viewModel = new GalleryImageManagerViewModel()
            {
                GalleryImage = new GalleryImage(),
                Galleries = _galleryRepository.Collection().ToList()
            };
           
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(GalleryImage galleryImage,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(galleryImage);
            }
            else
            {
                if (file!=null)
                {
                    galleryImage.GalleryImageUrl = galleryImage.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//GalleryImages//") + galleryImage.GalleryImageUrl);
                }
                _galleryImageRepository.Insert(galleryImage);
                _galleryImageRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string id)
        {
            GalleryImage galleryImage = _galleryImageRepository.Find(id);
            if (galleryImage==null)
            {
                return HttpNotFound();
            }
            else
            {
                GalleryImageManagerViewModel viewModel = new GalleryImageManagerViewModel()
                {
                    GalleryImage = galleryImage,
                    Galleries = _galleryRepository.Collection().ToList()
                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(string id,GalleryImage galleryImage,HttpPostedFileBase file)
        {
            GalleryImage galleryImageToEdit = _galleryImageRepository.Find(id);
            if (galleryImageToEdit==null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(galleryImage);
                }
                if (file!=null)
                {
                    galleryImageToEdit.GalleryImageUrl = galleryImage.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//GalleryImages//") + galleryImageToEdit.GalleryImageUrl);
                }
                galleryImageToEdit.Description = galleryImage.Description;
                galleryImageToEdit.Name = galleryImage.Name;
                galleryImageToEdit.GalleryName = galleryImage.GalleryName;

                _galleryImageRepository.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            GalleryImage galleryImage = _galleryImageRepository.Find(id);

            if (galleryImage==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(galleryImage);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            GalleryImage galleryImage = _galleryImageRepository.Find(id);
            if (galleryImage==null)
            {
                return HttpNotFound();
            }
            else
            {
                _galleryImageRepository.Delete(id);
                _galleryImageRepository.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}