using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.DB;
[Serializable]
public class StationElement
{
    public int Id { get; set; }
    public override string ToString()
    {
        return $"{Id}";
    }
    public bool IsCurve() {
        if(this.GetType()==typeof(RailCurve)) {
            return true;
        }
        return false;
    }
    public bool IsPoint() {
        if (this.GetType() == typeof(RailConnectionPoint)) {
            return true;
        }
        return false;
    }
}
