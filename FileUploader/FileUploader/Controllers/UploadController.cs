using AutoMapper;
using FileUploader.Data.Helpers;
using FileUploader.Data.Models;
using FileUploader.Data.Repositories;
using FileUploader.Data.Types;
using FileUploader.Data.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace FileUploader.Controllers
{
  public class UploadController : Controller
  {
    public ActionResult Index()
    {
      //create a repo instance
      var repo = new UploadRepository();

      //get the uploads
      var uploads = repo.GetAll();

      //map to the viewmodel
      var uploadModels = Mapper.Map<List<Upload>, List<UploadViewModel>>(uploads);

      //get the upload locations
      var uploadLocations = repo.GetLocations();

      //map to the viewmodel
      var uploadLocationModels = Mapper.Map<List<UploadLocation>, List<UploadLocationViewModel>>(uploadLocations);

      //create the page's viewmodel
      var model = new UploadIndexViewModel
      {
        UploadLocationViewModels = uploadLocationModels,
        UploadViewModels = uploadModels
      };
      
      //return the view
      return View(model);
    }

    public ActionResult New()
    {
      var model = new UploadEditViewModel();

      return View("Edit", model);
    }

    [HttpPost]
    public ActionResult Edit(UploadEditViewModel model)
    {
      var repo = new UploadRepository();

      //BudgetJustificationUploads
      var budgetJustifications = model.BudgetJustificationUploads;
            
      foreach (var fileBase in budgetJustifications)
      {
        //make the upload db entry
        var upload = new Upload
        {
          Extension = Path.GetExtension(fileBase.FileName),
          Subfolder = UploadHelper.GetUploadSubfolder(),
          Title = Path.GetFileNameWithoutExtension(fileBase.FileName),
          UploadType = UploadType.BudgetJustification
        };

        //save it
        upload = repo.Save(upload);

        //now that we have the metadata in the db, go ahead and write the file to disk
        var destPath = UploadHelper.GetUploadPath(repo.GetUploadLocation(upload.Id), 
          upload.Id, 
          Path.GetExtension(fileBase.FileName));

        fileBase.SaveAs(destPath);
      }
      
      return RedirectToAction("Index");
    }

    public ActionResult Download(int id)
    {
      var repo = new UploadRepository();

      var upload = repo.Get(id);
      var uploadLocation = repo.GetUploadLocation(upload.Id);
      var downloadPath = UploadHelper.GetDownloadPath(uploadLocation, 
        upload.Id, 
        upload.Subfolder, 
        upload.Extension);

      UploadHelper.DownloadFile(System.Web.HttpContext.Current,
        downloadPath, 
        upload.Id, 
        upload.Title, 
        upload.Extension);

      return null;
    }
  }
}
