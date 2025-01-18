using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class IteamsUnites
    {
        [ForeignKey(nameof(Units))]
        public int Unit_Id{ get; set; }
        [ForeignKey(nameof(Iteams))]
        public int Iteam_Id{ get;set; }
        public Units Units { get; set; }
        public int Factor {  get; set; }
        public Iteams Iteams { get; set; }

    }
}
