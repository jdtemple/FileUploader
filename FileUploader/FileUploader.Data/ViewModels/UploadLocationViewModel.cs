using FileUploader.Data.ViewModels.Base;

namespace FileUploader.Data.ViewModels
{
  public class UploadLocationViewModel : EntityViewModel
  {
    public string Path { get; set; }

    public int StartId { get; set; }
  }
}
