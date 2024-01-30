using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal abstract class O01Entity
    {
        [Key]
        public int id { get; set; }
    }
}
