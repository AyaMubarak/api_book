using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class ShoppingCartIteams
    {
        [ForeignKey(nameof(Iteams))]
    public int Iteam_Id { get; set; }
        [ForeignKey(nameof(Stores))]
    public int Store_Id { get; set; }
        [ForeignKey(nameof(Users))]

        public int Cus_Id { get; set; }
        public Users Users { get; set; }
        public Stores Stores { get; set; }
        public Iteams Iteams { get; set; }
        public double Quantity {  get; set; }
        [ForeignKey(nameof(Units))]
        public int Unit_Id {  get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime ? UpdatedAt { get; set; }
      

    }
}
