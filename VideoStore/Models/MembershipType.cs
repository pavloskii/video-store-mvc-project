using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

    }
}