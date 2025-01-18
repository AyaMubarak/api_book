using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IteamsUnites> IteamsUnites { get; set; } = new HashSet<IteamsUnites>();

    }
}
