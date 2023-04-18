using Station.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.UI;
 public  class CreationContaineer
{
    public RailConnectionPoint Start { get; set; }
    public RailConnectionPoint End { get;set; }

    internal void Reset() {
        Start = null;
        End = null;
    }
    public bool IsCreateSecondPoint() {
        if(Start!=null&&End==null) {
            return true;
        }
        else {
            return false;
        }
    }
}
