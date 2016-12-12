using FileUploader.Data.Interfaces;
using FileUploader.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;

namespace FileUploader.Data.Repositories
{
  public class UploadRepository : IUploadRepository
  {
    public List<UploadLocation> GetLocations()
    {
      using (var db = new FileUploaderContext())
      {
        return db.UploadLocations.ToList();
      }
    }

    public List<Upload> GetAll()
    {
      using (var db = new FileUploaderContext())
      {
        return db.Uploads.ToList();
      }
    }

    public string GetUploadLocation(int uploadId)
    {
      if (uploadId <= 0)
      {
        throw new Exception("uploadId must be greater than 0");
      }

      UploadLocation loc;

      using (var db = new FileUploaderContext())
      {
        loc = db.UploadLocations
          .OrderByDescending(x => x.StartId)
          .Where(x => x.StartId <= uploadId)
          .First();
      }

      return loc.Path;
    }

    public Upload Save(Upload entity)
    {
      using (var db = new FileUploaderContext())
      {
        if (entity.Id == 0)
        {
          db.Uploads.Add(entity);
        }
        else
        {
          db.Uploads.Attach(entity);
          db.Entry(entity).State = EntityState.Modified;
        }

        db.SaveChanges();

        return entity;
      }
    }

    public Upload Get(int id)
    {
      if (id <= 0)
      {
        throw new Exception("id must be greater than 0");
      }

      using (var db = new FileUploaderContext())
      {
        return db.Uploads.Single(x => x.Id == id);
      }
    }
  }
}
