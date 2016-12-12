using System.Collections.Generic;

namespace FileUploader.Data.ViewModels
{
  public class UploadIndexViewModel
  {
    public IEnumerable<UploadViewModel> UploadViewModels { get; set; }

    public IEnumerable<UploadLocationViewModel> UploadLocationViewModels { get; set; }
  }
}
