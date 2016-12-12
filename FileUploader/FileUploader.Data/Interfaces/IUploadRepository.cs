using FileUploader.Data.Models;
using System.Collections.Generic;

namespace FileUploader.Data.Interfaces
{
  public interface IUploadRepository
  {
    List<Upload> GetAll();

    List<UploadLocation> GetLocations();

    string GetUploadLocation(int uploadId);

    Upload Save(Upload entity);
  }
}
