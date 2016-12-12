using FileUploader.Data.Types;
using FileUploader.Data.ViewModels.Base;

namespace FileUploader.Data.ViewModels
{
  public class UploadViewModel : EntityViewModel
  {
    public string Extension { get; set; }
        
    public string Title { get; set; }

    public UploadType UploadType { get; set; }
  }
}
