using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Core.ViewModels
{
    public class ImagesByGalleryViewModel
    {
       
            public IEnumerable<Gallery> Galleries { get; set; }
            public IEnumerable<GalleryImage> GalleryImages { get; set; }

        
    }
}
