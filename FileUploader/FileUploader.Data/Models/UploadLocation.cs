using FileUploader.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FileUploader.Data.Models
{
  public class UploadLocation : Entity
  {
    [Required]
    public string Path { get; set; }

    public int StartId { get; set; }
  }
}
