using System;
using System.Collections.Generic;

namespace Budgeteer_Angular.Models
{
    public partial class Member
    {
        public int MembersId { get; set; }
        public int? GroupId { get; set; }
        public long? UserId { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
