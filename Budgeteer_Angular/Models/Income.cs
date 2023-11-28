using System;
using System.Collections.Generic;

namespace Budgeteer_Angular.Models
{
    public partial class Income
    {
        public int IncomeId { get; set; }
        public string Source { get; set; }
        public float? Amount { get; set; }
        public long? UserId { get; set; }
        public int? FrequencyId { get; set; }

        public virtual Frequency Frequency { get; set; }
        public virtual User User { get; set; }
    }
}
