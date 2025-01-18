using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class SubGroup2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(MainGroup))]
        public int MG_Id { get; set; }
        public MainGroup MainGroup  { get; set; }  
        [ForeignKey(nameof(SubGroup))]
        public int sub_Id { get; set; }
        public SubGroup SubGroup  { get; set; }
      public ICollection<Iteams>Iteams { get; set; }=new HashSet<Iteams>();
    }
}
