using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12.Models
{
    public class OrderedP
    {
        public bool isReserved { get; set; } = true;
        public bool isChecked { get; set; } = false;
        public string Name { get; set; }
    }
}
