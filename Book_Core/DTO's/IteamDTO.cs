﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.DTO_s
{
    public class IteamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> Stores { get; set; }
        public List<string> IteamsUnit { get; set; }

    }
}
