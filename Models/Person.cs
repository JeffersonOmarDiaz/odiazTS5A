﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odiazTS5A.Models
{
    public class Person
    {
        [PrimaryKey,AutoIncrement] 
        public int Id { get; set; }

        [MaxLength(25), Unique]
        public string Name { get; set; }
    }
}
