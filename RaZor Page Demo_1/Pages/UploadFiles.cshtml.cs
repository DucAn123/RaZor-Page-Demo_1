using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesLabA1.Pages
{
    public class UploadFilesModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public UploadFilesModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public async Task<IActionResult> OnPostUploadMultiAsync()
        {
            if (FileUploads != null)
            {
                foreach (var file in FileUploads)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "Images", file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            return Page();
        }
    }
}
