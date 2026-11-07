using System.ComponentModel.DataAnnotations;

namespace Club.Domain.LoyaltyAccountAgg.Enums;

public enum LoyaltyAccountStatus
{
    [Display(Name = "فعال")]
    Active = 1,

    [Display(Name = "مسدود شده")]
    Blocked = 2,

    [Display(Name = "بسته شده")]
    Closed = 3
}
