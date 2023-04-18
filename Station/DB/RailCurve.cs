using System;

namespace Station.DB;

[Serializable]
public class RailCurve : StationElement
{
    public RailConnectionPoint Start { get; set; }
    public RailConnectionPoint End { get; set; }
    public override string ToString() {
        return $"LID={this.Id} SID={Start.Id} EID={End.Id} leng={Start.DistanceTo(End)}";
    }

    internal double GetLeng() {
        double val = Start.DistanceTo(End);

        return val;
    }
}
