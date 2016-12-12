using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace FileUploader.Data.Helpers
{
  public static class UploadHelper
  {
    public static string GetUploadPath(string uploadLocation, int uploadId, string extension)
    {
      //create the root upload directory
      CreateDirectory(uploadLocation);

      //create the subfolder using the current year
      var uploadDir = string.Format("{0}\\{1}\\", uploadLocation, GetUploadSubfolder());

      CreateDirectory(uploadDir);

      //return the full path for the upload
      return string.Format("{0}{1}{2}", uploadDir, uploadId, extension);
    }

    public static string GetUploadSubfolder()
    {
      return DateTime.Now.Year.ToString();
    }

    public static string GetDownloadPath(string uploadLocation, int uploadId, string subfolder, string extension)
    {
      return string.Format("{0}\\{1}\\{2}{3}", uploadLocation, subfolder, uploadId, extension);
    }

    public static void DownloadFile(HttpContext context, string downloadPath, int id, string title, string extension)
    {
      //attempt to reconstruct the original file name
      //if it fails, just use id.extension
      var fileName = string.IsNullOrEmpty(MakeValidFileName(title)) ?
        string.Format("{0}{1}", id, extension) :
        string.Format("{0}{1}", MakeValidFileName(title), extension);

      var contentType = MimeMapping.GetMimeMapping(downloadPath);
      Stream fileStream = new FileStream(downloadPath, FileMode.Open);

      context.Response.Buffer = false;
      context.Response.ContentType = contentType;
      context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));

      var dataToRead = fileStream.Length;

      //read the file bytes
      while(dataToRead > 0)
      {
        //verify that the client is connected
        if (context.Response.IsClientConnected)
        {
          //8kB buffer
          var bufferSize = 8 * 1024;

          //create buffere for reading file bytes
          var byteBuffers = new byte[bufferSize];

          //read the data and put it in the buffer
          var bytesRead = fileStream.Read(buffer: byteBuffers, offset: 0, count: bufferSize);

          //write the data from the buffer to the current output stream
          context.Response.OutputStream.Write(buffer: byteBuffers, offset: 0, count: bytesRead);

          //flush (send) the data to output
          context.Response.Flush();

          //prepare to read the next chunk
          dataToRead = dataToRead - bytesRead;
        }
        else
        {
          //prevent infinite loop if user isn't connected
          dataToRead = -1;
        }
      }

      //clean up the resources
      if (fileStream != null)
      {
        fileStream.Close();
        fileStream.Dispose();
      }

      context.Response.Close();
    }

    private static void CreateDirectory(string path)
    {
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
    }

    /// <summary>
    /// remove invalid characters from the filename so it will not interfere with Response.Header
    /// </summary>
    /// <param name="oldFilename"></param>
    /// <returns></returns>
    private static string MakeValidFileName(string oldFilename)
    {
      string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
      string invalidReStr = string.Format(@"[{0}]", invalidChars);
      string validFilename = Regex.Replace(oldFilename, invalidReStr, "_").Replace(";", "").Replace(",", "");
      return validFilename;
    }
  }
}
