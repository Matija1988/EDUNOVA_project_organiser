﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public abstract  class Entity
    {
        [Key]
        public int id { get; set; }
    }
}
