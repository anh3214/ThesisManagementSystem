using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class ScoreWeight
    {
        [Key]
        public Guid WeightID { get; set; }

        public decimal AdvisorWeight { get; set; }
        public decimal ReviewerWeight { get; set; }
        public decimal CommitteeWeight { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
