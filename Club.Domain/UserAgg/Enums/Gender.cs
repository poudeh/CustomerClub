using System.ComponentModel.DataAnnotations;

namespace Club.Domain.UserAgg.Enums;

public enum Gender
{
    [Display(Name = "نامشخص")]
    Unknown,
    [Display(Name = "مرد")]
    Male,
    [Display(Name = "زن")]
    Female
}