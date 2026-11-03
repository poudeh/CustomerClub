using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Club.Domain.ClubMemberAgg.Enums;

public enum MemberStatus
{
    [Display(Name = "در انتظار تأیید")]
    Pending = 1,
    [Display(Name = "فعال")]
    Active = 2,
    [Display(Name = "تعلیق‌شده")]
    Suspended = 3,
    [Display(Name = "خاتمه‌یافته")]
    Terminated = 4
}
