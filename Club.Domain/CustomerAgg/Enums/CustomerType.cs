using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Club.Domain.CustomerAgg.Enums;

public enum CustomerType
{
    [Display(Name = "شخص حقیقی")]
    Individual = 1,

    [Display(Name = "شخص حقوقی")]
    LegalEntity = 2,

    [Display(Name = "مشارکت مدنی")]
    CivilPartnership = 3,

    [Display(Name = "اتباع خارجی")]
    ForeignNational = 4
}
