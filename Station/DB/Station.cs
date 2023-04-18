using System;
using System.Collections.Generic;
using System.Linq;

namespace Station.DB
{
    [Serializable]
    public class Station
    {
        public string Name { get; set; }
        private int lasElementId { get; set; } = 0;
        private Dictionary<int, StationElement> elemets { get; set; }
        private List<RailConnectionPoint> railConnecters { get; set; }
        private List<RailCurve> railCurves { get; set; }
        private List<RailPark> railParks { get; set; }

        public Station() {
            elemets = new Dictionary<int, StationElement>();
            railConnecters = new List<RailConnectionPoint>();
            railCurves = new List<RailCurve>();
            railParks = new List<RailPark>();

        }
        public StationElement GetElementById(int id) {
            return elemets[id];
        }
        public List<RailCurve> ToRailCurves() {
            return railCurves;
        }
        public List<RailPark> ToRailParks() {
            return railParks;
        }
        public List<RailConnectionPoint> ToRailConnections() {
            return railConnecters;
        }

        public RailPark CreateRailPark() {
            RailPark p = new RailPark();
            p.Name = "NewPark";
            AddElement(p);
            railParks.Add(p);

            return p;
        }
        public RailConnectionPoint CreatePoint(double x, double y) {
            RailConnectionPoint point = new RailConnectionPoint() { X = x, Y = y };
            railConnecters.Add(point);
            AddElement(point);
            return point;
        }

        public RailCurve CreateCurve(RailConnectionPoint start, RailConnectionPoint end) {
            RailCurve curve = new RailCurve() { Start = start, End = end };
            start.Add(curve);
            end.Add(curve);
            railCurves.Add(curve);
            AddElement(curve);
            return curve;
        }

        private void AddElement(StationElement element) {
            lasElementId++;
            element.Id = lasElementId;
            elemets.Add(lasElementId, element);
        }

        internal RailConnectionPoint GetSimilarPoint(double x, double y) {
            double k = 20;
            RailConnectionPoint p = null;
            p = railConnecters.Where(i =>
              i.X <= x + k
            && i.X >= x - k
            && i.Y <= y + k
            && i.Y >= y - k)
                .FirstOrDefault();

            return p;
        }
        public void RemoveElement(StationElement element) {

            if (element.IsPoint()) {
                RailConnectionPoint existPoint = this.elemets[element.Id] as RailConnectionPoint;

                foreach (RailCurve connected in existPoint.ConnectedCurves) {
                    RemoveCurve(connected);
                }
                RemovePoint(existPoint);

            }
            else if (element.IsCurve()) {

                RailCurve curve = element as RailCurve;
                curve.Start.ConnectedCurves.Remove(curve);
                curve.End.ConnectedCurves.Remove(curve);
                RemoveCurve(curve);
            }
            elemets.Remove(element.Id);

        }
        private void RemovePoint(RailConnectionPoint point) {
           railConnecters.Remove(point);
        }
        private void RemoveCurve(RailCurve? railCurve) {

            railCurves.Remove(railCurve);
        }
    }
}
