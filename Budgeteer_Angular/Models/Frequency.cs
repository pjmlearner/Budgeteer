using System;
using System.Collections.Generic;


namespace Budgeteer_Angular.Models
{
    public partial class Frequency
    {
        public Frequency()
        {
            Incomes = new HashSet<Income>();
        }

        public int FrequencyId { get; set; }
        public string FrequencyType { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
    }
}
