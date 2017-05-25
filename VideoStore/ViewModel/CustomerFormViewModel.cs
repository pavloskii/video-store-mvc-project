using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Models;

namespace VideoStore.ViewModel
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}