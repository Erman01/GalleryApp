using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Core.ViewModels
{
    public class GalleryImageManagerViewModel
    {
        public GalleryImage GalleryImage { get; set; }
        public IEnumerable<Gallery> Galleries { get; set; }
    }
}
