using System;
using System.Collections.Generic;

namespace Budgeteer_Angular.Models
{
    public partial class Group
    {
        public Group()
        {
            Members = new HashSet<Member>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
