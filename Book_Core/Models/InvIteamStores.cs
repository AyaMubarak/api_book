using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class InvIteamStores
    {
        [ForeignKey(nameof(Stores))]
        public int Store_Id { get; set; }
        public Stores Stores { get; set; }
        [ForeignKey(nameof(Iteams))]
        public int Iteam_Id { get; set; }
        public Iteams Iteams { get; set; }
        public double Balance { get; set; }
        public int Factor { get; set; }
        public double ReversedQuintity{get;set;}
        public DateTime LastUpdated {  get; set; }
    }
}
