using System;
using System.Collections.Generic;
using System.Text;
using Club.Domain.CustomerAgg;
using Common.Common.Domain.Repository;

namespace Club.Domain.ClubMemberAgg.Repository;

public interface IClubMemberRepository:IBaseRepository<ClubMember>
{
    public Task<ClubMember?> GetClubMemberByCustomer(long customerId);
}
