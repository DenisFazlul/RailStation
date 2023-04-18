using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Station.Models
{
    public  class ColorModel
    {
       public string Name { get; set; }

        public Brush Color { get; set; }
        public override string ToString() {
            return Name;
        }
    }
}
