using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FileUploader.Data.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<FileUploaderContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(FileUploaderContext db)
    {
      //This method will be called after migrating to the latest version.

      ////How to debug the seed
      ////1. uncomment the if block below
      ////2. launch a new instance of VS and open this project
      ////3. place your breakpoint(s) in the new instance of VS
      ////4. run update-database in the package manager console in this instance of VS
      ////5. when prompted, select the other VS instance for debugging
      //if (!Debugger.IsAttached)
      //{
      //  Debugger.Launch();
      //}

      SeedUploadLocations(db);
    }

    private void SeedUploadLocations(FileUploaderContext db)
    {
      //This seed has a little smarts in it to allow modification of an
      //existing UploadLocation, or creation of a new entry if one isn't there.
      try
      {
        var startId = 1;
        var defaultPath = @"C:\Uploads";
        var loc = db.UploadLocations.Where(x => x.StartId == startId).SingleOrDefault();
        
        if (loc != null)
        {
          //update the path if necessary
          loc.Path = defaultPath;
        }
        else
        {
          //create the entity
          loc = new Models.UploadLocation
          {
            Path = defaultPath,
            StartId = startId
          };

          //add it to the context
          db.UploadLocations.Add(loc);
        }

        db.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
