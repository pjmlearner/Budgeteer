using System;
using System.Collections.Generic;

namespace Budgeteer_Angular.Models
{
    public partial class User
    {
        public User()
        {
            Incomes = new HashSet<Income>();
            Members = new HashSet<Member>();
        }

        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
