using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CallApiiWithWinForm.Models
{
    public partial class Factor
    {
        public long Id { get; set; }
        public long FCustomerId { get; set; }
        public long FProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Customer FCustomer { get; set; }
    }
}
