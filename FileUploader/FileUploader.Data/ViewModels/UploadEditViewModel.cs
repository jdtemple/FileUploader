using System.Collections.Generic;
using System.Web;

namespace FileUploader.Data.ViewModels
{
  public class UploadEditViewModel
  {
    public IEnumerable<HttpPostedFileBase> BudgetJustificationUploads { get; set; }
  }
}
