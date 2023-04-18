using System;
using System.Collections.Generic;
using System.Text;

namespace Station.DB;
[Serializable]
public class RailPark : StationElement
{
    public string Name { get; set; }
    public List<RailCurve> Segments { get; set; }
    public RailPark() {
        Segments = new List<RailCurve>();

    }
    public List<int> GetCurvesIds() {
        List<int> ids = new List<int>();
        foreach (RailCurve c in Segments) {
            ids.Add(c.Id);
        }
        return ids;
    }
    public void AddSegment(RailCurve curve) {
        Segments.Add(curve);
    }
    public override string ToString() {
        StringBuilder bd = new StringBuilder();
        bd.Append($"Park={this.Name}");
        bd.Append("(");
        foreach (RailCurve curves in Segments) {
            bd.Append($"LID={curves.Id}");
        }
        bd.Append(")");
        return bd.ToString();
    }

    internal List<RailConnectionPoint> getPoints() {
        List<RailConnectionPoint> list = new List<RailConnectionPoint>();
        foreach (RailCurve c in Segments) {

            if (list.Contains(c.Start) == false) {
                list.Add(c.Start);

            }
            if (list.Contains(c.End) == false) {
                list.Add(c.End);

            }
        }
        return list;
    }
}
