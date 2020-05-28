using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class GalleryImage:BaseEntity
    {
        public string Id { get; set; }
        [StringLength(50)]
        [Display(Name="Image Name")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name="Image Description")]
        public string Description { get; set; }
        public string GalleryName { get; set; }
        [Display(Name = "Image")]
        public string GalleryImageUrl { get; set; }
        public GalleryImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
