using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Display(Name = "Subscribe to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        #region Navigation Properties
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        #endregion
    }
}