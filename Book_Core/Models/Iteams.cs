using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class Iteams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price {  get; set; }
        [ForeignKey(nameof(MainGroup))]
        public int MG_Id { get; set; }
        public MainGroup MainGroup {  get; set; }
        [ForeignKey(nameof(SubGroup))]
        public int Sub_Id { get; set; }
        public SubGroup SubGroup {  get; set; } 
        [ForeignKey(nameof(SubGroup2))]
        public int Sub2_Id { get; set; }
        public SubGroup2 SubGroup2 {  get; set; }
        public ICollection<InvIteamStores> InvIteamStores { get; set; }=new HashSet<InvIteamStores>();
        public ICollection<IteamsUnites> IteamsUnites { get; set; }=new HashSet<IteamsUnites>();
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }=new HashSet<InvoiceDetails>();

    }
}
