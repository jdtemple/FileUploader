using System;
using System.IO;

namespace FileUploader.Data.Helpers
{
  public static class UploadHelper
  {
    public static string GetUploadPath(string uploadLocation, int uploadId, string extension)
    {
      //create the root upload directory
      CreateDirectory(uploadLocation);

      //create the subfolder using the current year
      var uploadDir = string.Format("{0}\\{1}\\", uploadLocation, DateTime.Now.Year);

      CreateDirectory(uploadDir);

      //return the full path for the upload
      return string.Format("{0}{1}{2}", uploadDir, uploadId, extension);
    }

    private static void CreateDirectory(string path)
    {
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
    }
  }
}
