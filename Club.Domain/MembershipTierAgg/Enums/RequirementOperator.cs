using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Club.Domain.MembershipTierAgg.Enums;

public enum RequirementOperator
{
    [Display(Name = "بزرگتر یا مساوی")]
    GreaterThanOrEqual = 1,

    [Display(Name = "بزرگتر از")]
    GreaterThan = 2,

    [Display(Name = "برابر با")]
    Equal = 3,

    [Display(Name = "کوچکتر از")]
    LessThan = 4,

    [Display(Name = "کوچکتر یا مساوی")]
    LessThanOrEqual = 5,

    [Display(Name = "مخالف")]
    NotEqual = 6
}
