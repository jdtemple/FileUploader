using FileUploader.Data.Models.Base;
using FileUploader.Data.Types;

namespace FileUploader.Data.Models
{
  public class Upload : Entity
  {
    public string Extension { get; set; }
    
    public string Title { get; set; }

    public UploadType UploadType { get; set; }
  }
}
