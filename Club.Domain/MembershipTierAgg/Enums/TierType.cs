using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Club.Domain.MembershipTierAgg.Enums;

public enum TierType
{
    [Display(Name = "برنزی")]
    Bronze = 1,

    [Display(Name = "نقره‌ای")]
    Silver = 2,

    [Display(Name = "طلایی")]
    Gold = 3,

    [Display(Name = "پلاتینیوم")]
    Platinum = 4,

    [Display(Name = "الماسی")]
    Diamond = 5
}
