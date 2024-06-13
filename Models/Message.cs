﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
