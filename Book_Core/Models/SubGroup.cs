using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class SubGroup
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(MainGroup))]
        public int MG_Id {  get; set; }
        public MainGroup MainGroup { get; set; }
        public ICollection<Iteams> Iteams { get; set; }=new HashSet<Iteams>();
        public ICollection<SubGroup2> SubGroup2 { get; set; } = new HashSet<SubGroup2>();

    }
}
