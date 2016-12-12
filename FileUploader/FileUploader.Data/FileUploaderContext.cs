using FileUploader.Data.Models;
using System.Data.Entity;

namespace FileUploader.Data
{
  public class FileUploaderContext : DbContext
  {
    public FileUploaderContext() : base ("FileUploaderContext")
    {
      Configuration.LazyLoadingEnabled = false;
      Configuration.ProxyCreationEnabled = false;
    }

    #region DbSets
    public virtual DbSet<Upload> Uploads { get; set; }

    public virtual DbSet<UploadLocation> UploadLocations { get; set; }
    #endregion
  }
}
