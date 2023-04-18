using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Station.DB;

[Serializable]
public class RailConnectionPoint : StationElement
{
    public double X { get; set; }
    public double Y { get; set; }
    public List<RailCurve> ConnectedCurves { get; set; }
    public RailConnectionPoint(Point p) {
        ConnectedCurves = new List<RailCurve>();
        X = p.X;
        Y = p.Y;
    }
    public RailConnectionPoint() {
        ConnectedCurves = new List<RailCurve>();
    }
    public void Add(RailCurve curve) {
        RailCurve exist = ConnectedCurves.Where(i => i.Id == curve.Id).FirstOrDefault();
        if (exist == null) {
            ConnectedCurves.Add(curve);
        }
    }
    public bool IsSimilarByY(RailConnectionPoint p1) {
        double k = 16;
        if (Y <= p1.Y + k
            &&
            Y >= p1.Y - k) {
            return true;
        }
        return false;
    }

    public override string ToString() {
        StringBuilder bd = new StringBuilder();

        bd.Append($"PID={this.Id}");
        foreach (RailCurve curves in ConnectedCurves) {
            bd.Append($"LID={curves.Id}");
        }
        return bd.ToString();
    }
}
