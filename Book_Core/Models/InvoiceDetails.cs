using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class InvoiceDetails
    {
          [ForeignKey(nameof(Iteams))]
        public int Iteam_Id { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int Invoice_Id { get; set; }
        public Iteams Iteams { get; set; }
        public Invoice Invoice { get; set; }
        public double Price {  get; set; }
        [ForeignKey(nameof(Units))]
        public int Unit_id {  get; set; }
        public double Factor {  get; set; }
        public DateTime CreatedAt { get; set; }
        public double Quantity {  get; set; }
    }
}
