using System.ComponentModel.DataAnnotations;

namespace FileUploader.Data.Types
{
  public enum UploadType
  {
    [Display(Name = "Budget Justification")]
    BudgetJustification = 1,

    [Display(Name = "Narrative")]
    Narrative = 2,

    [Display(Name = "Other")]
    Other = 3,

    [Display(Name = "Real Estate")]
    RealEstate = 4,

    [Display(Name = "Sponsor Letter")]
    SponsorLetter = 5
  }
}
