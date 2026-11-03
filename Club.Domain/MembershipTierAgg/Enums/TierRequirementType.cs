using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Club.Domain.MembershipTierAgg.Enums;

public enum TierRequirementType
{
    [Display(Name = "حداقل امتیاز")]
    MinimumPoints = 1,
    [Display(Name = "حداقل تعداد صورتحساب")]
    MinimumInvoiceCount = 2,
    [Display(Name = "حداقل مبلغ صورتحساب")]
    MinimumInvoiceAmount = 3,
    [Display(Name = "حداقل سابقه عضویت")]
    MinimumMembershipDuration = 4,
    [Display(Name = "نرخ موفقیت ارسال")]
    MinimumSuccessRate = 5
}
