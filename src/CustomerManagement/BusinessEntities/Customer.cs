using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.BusinessEntities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string CustomerPhoneNumber { get; set; }

        [EmailAddress]
        public string CustomerEmail { get; set; }

        public decimal TotalPurchaseAmount { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
