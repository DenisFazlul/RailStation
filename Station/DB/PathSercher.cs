using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Station.DB
{
    public class CurvesPath {

        public List<RailCurve> Curves { get; set; }
        public CurvesPath() { 
        Curves = new List<RailCurve>();
        }
        public double leng { get; set; }

        internal void CalculateLenght() {
            foreach(RailCurve curve in Curves) {
                leng = leng + curve.GetLeng();
            }
        }
        public List<int> GetCurvesIds() {
            List<int> ids = new List<int>();
            foreach(RailCurve curve in Curves) {
                ids.Add(curve.Id);
            }
            return ids;
        }
    }
    public class PathSercher
    {
        public delegate void SerchNotification(CurvesPath sercher);

        public event SerchNotification Iteration;
        public event SerchNotification OnSercjCompleate;
        public event SerchNotification OnFindShortestPath;
        public event SerchNotification OnSerchStart;

        private RailConnectionPoint _start;
        private RailConnectionPoint _end;

        private List<RailCurve> _currentCurves;
        private List<CurvesPath> paths { get; set; }
        private CurvesPath _sortestPath;

        public PathSercher() {
            paths = new List<CurvesPath>();

        }
        public CurvesPath GetfastedPath() {


             return _sortestPath;
        }
         
        public void SetStartPoint(RailConnectionPoint st) {
            _start= st;
        }
        public void SetEndPoint(RailConnectionPoint st) { 
        
            _end= st;
        }
        public void RunSerch() {

            OnSerchStart?.Invoke(_sortestPath);
            _currentCurves= new List<RailCurve>();
            RunRecurcive(_start);
            OnSercjCompleate?.Invoke(_sortestPath);
           

        }
         
        private void RunRecurcive(RailConnectionPoint p) {

            
            //Thread.Sleep(500);

           // Iteration.Invoke(this);
            if(p.Id==_end.Id) {
                Iteration?.Invoke(_sortestPath);
                CreatePath();
                return;
            }
            else if(p.ConnectedCurves.Count==0) {
                return;
            }

            foreach(RailCurve curv in p.ConnectedCurves) {

                if(_currentCurves.Contains(curv)) {
                    continue;
                }
                RailConnectionPoint next= null;
                if(curv.Start.Id==p.Id) {
                    next = curv.End;
                }
                else {
                    next = curv.Start;
                }
                _currentCurves.Add(curv);
                RunRecurcive(next);
                _currentCurves.Remove(curv);
            }
        }
        private void CreatePath() {

            CurvesPath p = new CurvesPath();
            foreach(RailCurve curv in _currentCurves) {
                p.Curves.Add(curv);
            }
            
            p.CalculateLenght();

            CurvesPath ShotestPath = this.paths.Where(i => i.leng < p.leng).FirstOrDefault();


            if(ShotestPath==null) {
                _sortestPath = p;
                OnFindShortestPath.Invoke(_sortestPath);
            }
            this.paths.Add(p);

        }
       
    }
}
