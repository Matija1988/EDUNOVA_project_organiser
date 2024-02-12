using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.ObjectClasses
{
    internal abstract class Entity
    {
        [Key]
        public int id { get; set; }
    }
}
