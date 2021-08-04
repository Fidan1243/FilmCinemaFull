using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12.Models
{
    public class Film
    {
        public string ImagePath { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public List<OrderedP> Ordered { get; set; } = new Repostory.Repo().GetAllOrdered();
    }
}
