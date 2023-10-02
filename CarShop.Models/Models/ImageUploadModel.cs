using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models
{
   public class ImageUploadModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
