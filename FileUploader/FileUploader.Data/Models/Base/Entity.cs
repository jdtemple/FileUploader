using System.ComponentModel.DataAnnotations;

namespace FileUploader.Data.Models.Base
{
  public class Entity
  {
    [Key]
    public virtual int Id { get; set; }
  }
}
