using GalleryApp.Core.Contracts;
using GalleryApp.Core.Models;
using GalleryApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleryApp.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Gallery> _galleryRepository;
        IRepository<GalleryImage> _galleryImageRespository;
        public HomeController(IRepository<Gallery> galleryRepository, IRepository<GalleryImage> galleryImageRespository)
        {
            _galleryImageRespository = galleryImageRespository;
            _galleryRepository = galleryRepository;
        }
        public ActionResult Index(string GalleryName = null)
        {
          
            List<GalleryImage> galleryImageList;
            List<Gallery> galleryList = _galleryRepository.Collection().ToList();

            if (GalleryName == null)
            {
                galleryImageList = _galleryImageRespository.Collection().ToList();
               
            }
            else
            {
                galleryImageList = _galleryImageRespository.Collection().Where(x=>x.GalleryName== GalleryName).ToList();

            }
            ImagesByGalleryViewModel viewModel = new ImagesByGalleryViewModel()
            {
                Galleries = galleryList,
                GalleryImages = galleryImageList
            };
            return View(viewModel);

        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}