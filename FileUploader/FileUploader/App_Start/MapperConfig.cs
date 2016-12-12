using AutoMapper;
using FileUploader.Data.Models;
using FileUploader.Data.ViewModels;

namespace FileUploader.App_Start
{
  public static class MapperConfig
  {
    public static void RegisterMaps()
    {
      Mapper.Initialize(x => {
        x.CreateMap<Upload, UploadViewModel>();
        x.CreateMap<UploadViewModel, Upload>();
        x.CreateMap<UploadLocation, UploadLocationViewModel>();
        x.CreateMap<UploadLocationViewModel, UploadLocation>();
      });
    }
  }
}