using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.DB
{
    public class SotringPoint {
        
        public RailConnectionPoint Point { get; set; }
        public double angle { get; set; }
    }
    public class PointsSorter
    {
        private List<RailConnectionPoint> points { get; set; }
        private List<SotringPoint> sortingPoinst { get; set; }

        private RailConnectionPoint centerPoint { get; set; }
         
        public PointsSorter() {
            points = new List<RailConnectionPoint>();
            sortingPoinst= new List<SotringPoint>();
        }
        public void Sort(List<RailConnectionPoint> points) {
            this.points = points;
            centerPoint = GetCenter(this.points);
            
            foreach(RailConnectionPoint point in points) {

                SotringPoint p = new SotringPoint() { Point = point };
                sortingPoinst.Add(p);
                p.angle = CalculateAnge(p);
            }

            sortingPoinst=sortingPoinst.OrderBy(i=>i.angle).ToList();
             

        }
        public List<RailConnectionPoint> GetSortedPoints() {
            List<RailConnectionPoint> ps = new List<RailConnectionPoint>();
            foreach(SotringPoint s in sortingPoinst) {
                ps.Add(s.Point);
            }
            return ps;
        }
        private double CalculateAnge(SotringPoint point) {
            double val = 0;

            RailConnectionPoint A = new RailConnectionPoint() { X = point.Point.X, Y = centerPoint.Y };

            double katetVertical = point.Point.DistanceTo(A); 
            double katetHorizontal = centerPoint.DistanceTo(A);
            double gipotenuza = point.Point.DistanceTo(centerPoint);
             
            double angle =   Math.Acos(katetHorizontal/gipotenuza);

            angle = angle *  180/ Math.PI;

            if(point.Point.X<centerPoint.X&&point.Point.Y<centerPoint.Y) {
                val = angle;
            }
            else if(point.Point.X>centerPoint.X&&point.Point.Y<centerPoint.Y) {
                val = 180 - angle;
            }
            else if(point.Point.X>centerPoint.X&&point.Point.Y>centerPoint.Y) {
                val = 180 + angle;
            }
            else if(point.Point.X<centerPoint.X&&point.Point.Y>centerPoint.Y) {
                val = 180 + (180 - angle);
            }

            Debug.WriteLine($"{point.Point.Id} gip={gipotenuza} katet={katetHorizontal} ange={val}");
            return val;
        }
         
       
        private RailConnectionPoint GetCenter(List<RailConnectionPoint> points) {
            RailConnectionPoint center = new RailConnectionPoint();
           
           double maxX= points.Max(i => i.X);
            double maxY= points.Max(j => j.Y);

            double minX=points.Min(i => i.X);
            double minY= points.Min(j => j.Y);
            

            center.X=maxX-((maxX-minX)/2);
            center.Y=maxY-((maxY-minY)/2);

           
            return center;

        }
    }
}
