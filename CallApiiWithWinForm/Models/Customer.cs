using System;
using System.Collections.Generic;
using CallApiiWithWinForm.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CallApiiWithWinForm.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Factor = new HashSet<Factor>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }

        public virtual ICollection<Factor> Factor { get; set; }
    }
}
