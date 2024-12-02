using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class DefenseScore
    {
        [Key]
        public Guid DefenseID { get; set; }
        public virtual Defense Defense { get; set; }

        public Guid LecturerID { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public decimal Score { get; set; }

        public string Comments { get; set; }
    }
}
