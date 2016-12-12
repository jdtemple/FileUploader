using System;
using System.ComponentModel.DataAnnotations;

namespace FileUploader.Data.Types
{
  public static class TypeHelper
  {
    public static string GetDisplayName(Enum value)
    {
      if (value == null)
      {
        return null;
      }

      var fieldInfo = value.GetType().GetField(value.ToString());

      var displayAttributes = fieldInfo
        .GetCustomAttributes(typeof(DisplayAttribute), false)
          as DisplayAttribute[];

      if (displayAttributes == null ||
        displayAttributes.Length == 0 ||
        string.IsNullOrEmpty(displayAttributes[0].Name))
      {
        return value.ToString();
      }
      else
      {
        return displayAttributes[0].Name;
      }
    }
  }
}
