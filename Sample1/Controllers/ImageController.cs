using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample1.Modals;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        //Upload: api/Image
        [HttpPost]
        public async Task<ContentResult> PostImage()
        {
            image image = new image();
            var files = Request.Form.Files;
            if (files != null)
            {


                var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img");
                if (files.First().Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(files.First().FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await files.First().CopyToAsync(fileStream);
                        image.url = fileName;
                    }

                }
            }
            string json = JsonConvert.SerializeObject(image);
                return new ContentResult { Content = json, ContentType = "application/json" }; ;
        }
    }
}